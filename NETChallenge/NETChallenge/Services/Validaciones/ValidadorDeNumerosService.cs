using NETChallenge.Exceptions;

namespace NETChallenge.Services.Validaciones
{
    public class ValidadorDeNumerosService
    {
        public void ValidarNumeroMayorAOtro<T>(string campo, T numeroAValidar, T numeroMayor = default)
        {
            if (Comparer<T>.Default.Compare(numeroAValidar, numeroMayor) <= 0)
            {
                throw new ValorNoSuperaMinimoException(campo, numeroMayor.ToString());
            }
        }
    }
}
