using Microsoft.EntityFrameworkCore;
using EstructurasFinal.Models;
using EstructurasFinal.Services.Cita;

namespace EstructurasFinal.Services.Implementacion
{
    public class PacienteService
    {
        private EstructurasFinalContext _dbContext;

        public PacienteService(EstructurasFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Paciente>> GetList()
        {
            try
            {
                List<Paciente> lista = new List<Paciente>();
                lista = await _dbContext.Pacientes.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
