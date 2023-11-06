namespace challenge.Dto.Auditoria
{
    public class AuditoriaGetDto
    {
        public int Id {get; set; }
        public DateTime Fecha { get; set; }
        public string TipoOperacionAuditoria { get; set; }
        public int TipoOperacionAuditoriaId { get; set; }
        public string Tabla { get; set; }
        public int UsuarioId {get;set; }
        public string NombreUsuario { get; set; }
        public AuditoriaGetDto()
        {

        }
    }
}
