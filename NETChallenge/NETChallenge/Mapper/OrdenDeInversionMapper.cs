using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Models;

namespace challenge.Mapper
{
    public class OrdenDeInversionMapper
    {
        public static OrdenDeInversionDto Map(OrdenDeInversion orden)
        {
            if (orden == null)
            {
                return null;
            }

            return new OrdenDeInversionDto
            {
                Id = orden.Id,
                CuentaId = orden.CuentaId,
                NombreActivo = orden.TipoDeActivo.Descripcion,
                Cantidad = orden.Cantidad,
                Precio = orden.Precio,
                Operacion = orden.OrdenDeInversionOperacion.Identificador,
                EstadoId = orden.EstadoId,
                MontoTotal = orden.MontoTotal
            };
        }
    }
}
