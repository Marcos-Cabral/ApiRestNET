using NETChallenge.Models;

namespace NETChallenge.Interfaces.Services
{
    public interface IAccionService
    {
        public List<Accion> GetAll();
        public Accion GetById(int id);
    }
}
