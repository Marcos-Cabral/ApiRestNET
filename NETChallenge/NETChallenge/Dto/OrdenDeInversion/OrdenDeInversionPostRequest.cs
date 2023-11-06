namespace NETChallenge.Dto.OrdenDeInversion
{
    public class OrdenDeInversionPostRequest
    {
        /// <summary>
        /// Id de la Cuenta comitente
        /// </summary>
        public int CuentaId { get; set; }

        /// <summary>
        /// Es el Id del Tipo de Activo. Puede consultar los Tipos en (api/TipoDeActivo/get/)
        /// </summary>
        public int TipoActivoId { get; set; }

        /// <summary>
        /// Cantidad de la Orden
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio de la Orden
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Es el Id de la Operación de la Orden. Puede consultar las Operaciones en (api/OrdenDeInversionTipoOperacion/get/)
        /// </summary>
        public int OrdenDeInversionOperacionId { get; set; }

       /// <summary>
        /// Es el Id de la Acción. Solo aplica si el Tipo de Activo es del tip Acción. Puede consultar las Acciones en (api/Accion/get/)
        /// </summary>
        public int? AccionId { get; set; }
    }
}
