using challenge.Mapper;
using Microsoft.EntityFrameworkCore;
using NETChallenge.Data;
using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Enums;
using NETChallenge.Exceptions;
using NETChallenge.Models;
using NETChallenge.Services.Validaciones;

namespace NETChallenge.Services
{
    public class OrdenDeInversionService
    {
        private readonly ContextDB _context;
        private AuditoriaService _auditoria;
        private readonly OrdenDeInversionValidadorService _ordenDeInversionValidadorService;
        private readonly EstadoOrdenDeInversionService _estadoService;
        private readonly TipoDeActivoService _tipoDeActivoService;
        public OrdenDeInversionService(ContextDB context, AuditoriaService auditoria, 
            OrdenDeInversionValidadorService ordenDeInversionValidadorService,
            EstadoOrdenDeInversionService estadoOrdenDeInversionService, TipoDeActivoService tipoDeActivoService)
        {
            _context = context;
            _auditoria = auditoria;
            _ordenDeInversionValidadorService = ordenDeInversionValidadorService;
            _estadoService = estadoOrdenDeInversionService;
            _tipoDeActivoService = tipoDeActivoService;
        }

        public List<OrdenDeInversionDto> GetAll(OrdenDeInversionFiltroDto filtro)
        {
            return _context.OrdenDeInversion
                .Include(o=> o.TipoDeActivo)
                .Include(o=> o.OrdenDeInversionOperacion)
                .AsSplitQuery()
                .Where(e=> filtro == null || (filtro.Activo == null || filtro.Activo == (e.FechaBaja == null)))
                .Select(e => OrdenDeInversionMapper.Map(e))
                .ToList();
        }

        public OrdenDeInversion GetById(int id)
        {
            var ordenDeInversion = _context.OrdenDeInversion
                .Include(o=> o.TipoDeActivo)
                .Include(o=> o.OrdenDeInversionOperacion)
                .AsSplitQuery()
                .FirstOrDefault(e=> e.Id == id);
            if (ordenDeInversion == null)
            {
                throw new EntidadNoEncontradaException("No se encontró la orden de inversión");
            }
            return ordenDeInversion;
        }
        public bool Delete(int id)
        {
            var ordenDeInversion = GetById(id);
            _ordenDeInversionValidadorService.ValidarEliminacion(ordenDeInversion.FechaBaja);
            ordenDeInversion.FechaBaja = DateTime.UtcNow;
            _auditoria.RegistrarAuditoria(TiposOperacionesAuditoria.Baja, "OrdenDeInversion");
            _context.SaveChanges();
            return true;
        }

        public OrdenDeInversionDto Create(OrdenDeInversionPostRequest req)
        {
            _ordenDeInversionValidadorService.ValidarCreacion(req);

            var ordenDeInversion = new OrdenDeInversion
            {
                CuentaId = req.CuentaId,
                Cantidad = req.Cantidad,
                Precio = req.Precio,
                OrdenDeInversionOperacionId = req.OrdenDeInversionOperacionId,
                EstadoId = (int) EstadosDeOrdenesDeInversion.EnProceso,
                TipoDeActivoId = req.TipoActivoId
            };

            var montoTotal = _tipoDeActivoService.GetMontoTotal(req, ordenDeInversion);
            _ordenDeInversionValidadorService.ValidarMontoTotal(montoTotal);
            ordenDeInversion.MontoTotal = montoTotal;

            _context.OrdenDeInversion.Add(ordenDeInversion);

            _auditoria.RegistrarAuditoria(TiposOperacionesAuditoria.Alta, "OrdenDeInversion");
            
            _context.SaveChanges();
            
            _context.Entry(ordenDeInversion).Reference(o => o.TipoDeActivo).Load();
            _context.Entry(ordenDeInversion).Reference(o => o.OrdenDeInversionOperacion).Load();

            return OrdenDeInversionMapper.Map(ordenDeInversion);
        }

        public OrdenDeInversionDto Put(OrdenDeInversionPutRequest req)
        {
            var ordenDeInversion = GetById(req.Id);
            _ordenDeInversionValidadorService.ValidarEliminacion(ordenDeInversion.FechaBaja);
            if(!req.EstadoId.HasValue || req.EstadoId == ordenDeInversion.EstadoId) OrdenDeInversionMapper.Map(ordenDeInversion);

            _estadoService.ExisteId(req.EstadoId.Value);
            ordenDeInversion.EstadoId = req.EstadoId.Value;
            _auditoria.RegistrarAuditoria(TiposOperacionesAuditoria.Modificacion, "OrdenDeInversion");
            _context.SaveChanges();
            return OrdenDeInversionMapper.Map(ordenDeInversion);
        }
    }
}