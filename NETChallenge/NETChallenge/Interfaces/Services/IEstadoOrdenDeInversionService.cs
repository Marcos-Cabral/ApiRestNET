using NETChallenge.Models;

namespace NETChallenge.Interfaces.Services
{
    public interface IEstadoOrdenDeInversionService
    {
        public List<EstadoOrdenDeInversion> GetAll();
        public EstadoOrdenDeInversion GetById(int id);
    }
}
