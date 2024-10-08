using Practica05.Data.Models;

namespace Practica05.Data.Repositories
{
    public interface ITurnoRepository
    {
        List<TTurno> GetAll();
        TTurno GetById(int id);
        List<TTurno> GetCancel(int n);
        bool Create(TTurno turno);
        bool Delete(int id, string motivo);
        bool Update(TTurno turno, int id);
    }
}
