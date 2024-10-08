using Practica05.Data.Models;

namespace Practica05.Data.Services
{
    public interface IServicioService
    {
        List<TServicio> RecuperarEnPromo();
        TServicio? RecuperarPorID(int id);
        bool AgregarServicio(TServicio oServicio);
        bool ActualizarServicio(TServicio oServicio, int id);
        bool SacarPromocion(int id);
    }
}
