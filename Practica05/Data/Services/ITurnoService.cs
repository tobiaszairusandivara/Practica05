using Practica05.Data.Models;

namespace Practica05.Data.Services
{
    public interface ITurnoService
    {
        List<TTurno> GetAll();
        TTurno VerificarTurno(int id);
        List<TTurno> TurnoCancelado(int n);
        bool Create(TTurno turno);
        bool Delete(int id, string motivo);
        bool Update(TTurno turno, int id);
    }
}
