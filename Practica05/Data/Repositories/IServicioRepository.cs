using Practica05.Data.Models;

namespace Practica05.Data.Repositories
{
    public interface IServicioRepository
    {
        List<TServicio> GetAll();
        TServicio? GetById(int id);
        bool Create(TServicio oServicio);
        bool Update(TServicio oServicio, int id);
        bool Delete(int id);
    }
}
