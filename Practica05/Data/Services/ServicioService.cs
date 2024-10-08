using Practica05.Data.Models;
using Practica05.Data.Repositories;

namespace Practica05.Data.Services
{
    public class ServicioService : IServicioService
    {

        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public bool ActualizarServicio(TServicio oServicio, int id)
        {
            return _repository.Update(oServicio, id);
        }

        public bool AgregarServicio(TServicio oServicio)
        {
            return _repository.Create(oServicio);
        }

        public TServicio? RecuperarPorID(int id)
        {
            return _repository.GetById(id);
        }

        public List<TServicio> RecuperarEnPromo()
        {
            return _repository.GetAll();
        }

        public bool SacarPromocion(int id)
        {
            return _repository.Delete(id);
        }
    }
}
