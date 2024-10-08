using Microsoft.EntityFrameworkCore;
using Practica05.Data.Models;

namespace Practica05.Data.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly TurnoDbContext _context;

        public TurnoRepository(TurnoDbContext context)
        {
            _context = context;
        }

        public bool Create(TTurno turno)
        {
            _context.TTurnos.Add(turno);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id, string motivo)
        {
            var turno = _context.TTurnos.Find(id);
            if(turno != null)
            {
                turno.FechaCancelacion = DateTime.Now;
                turno.MotivoCancelacion = motivo;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos
                .Where(x => x.FechaCancelacion.HasValue == false)
                .ToList();
        }

        public TTurno GetById(int id)
        {
            var turno = _context.TTurnos
                .Where(x => x.Id == id) 
                .FirstOrDefault(); 
            return turno; 
        }

        public List<TTurno> GetCancel(int n)
        {
            return _context.TTurnos
                .Where(x => x.FechaCancelacion.HasValue) 
                .ToList();      
        }

        public bool Update(TTurno turno, int id)
        {
            var turnoExists = _context.TTurnos.Find(id);
            if (turnoExists != null)
            {
                // Actualizar las propiedades del turno existente con los valores del objeto nuevo
                turnoExists.Fecha = turno.Fecha;
                turnoExists.Hora = turno.Hora;
                turnoExists.Cliente = turno.Cliente;
                turnoExists.FechaCancelacion = turno.FechaCancelacion;
                turnoExists.MotivoCancelacion = turno.MotivoCancelacion;

                _context.TTurnos.Update(turnoExists);
                return _context.SaveChanges() > 0;
            }
            return false; 
        }
    }
}
