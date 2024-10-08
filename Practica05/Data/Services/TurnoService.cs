using Practica05.Data.Repositories;
using Practica05.Data.Models;

namespace Practica05.Data.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _tRepository;

        public TurnoService(ITurnoRepository tRepository)
        {
            _tRepository = tRepository;
        }

        public bool Create(TTurno turno)
        {
            return _tRepository.Create(turno);
        }

        public bool Delete(int id, string motivo)
        {
            return _tRepository.Delete(id, motivo);
        }

        public List<TTurno> GetAll()
        {
            return _tRepository.GetAll();
        }

        public List<TTurno> TurnoCancelado(int n)
        {
            return _tRepository.GetCancel(n);
        }

        public bool Update(TTurno turno, int id)
        {
            return _tRepository.Update(turno, id);
        }

        public TTurno VerificarTurno(int id)
        {
            return _tRepository.GetById(id);
        }
    }
}
