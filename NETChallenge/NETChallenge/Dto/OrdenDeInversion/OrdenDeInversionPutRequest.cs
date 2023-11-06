namespace NETChallenge.Dto.OrdenDeInversion
{
    public class OrdenDeInversionPutRequest
    {
        /// <summary>
        /// Id de la Orden de Inversión a modificar Puede consultar los Estados en (api/OrdenDeInversion/get/)
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }
        /// <summary>
        /// Es el Id del estado a modificar. Puede consultar los Estados en (api/EstadoOrdenDeInversion/get/)
        /// </summary>
        /// <example>1</example>
        public int? EstadoId { get; set; }
    }
}
