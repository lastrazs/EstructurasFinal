using Microsoft.EntityFrameworkCore;
using EstructurasFinal.Models;
using EstructurasFinal.Services.Cita;

namespace EstructurasFinal.Services.Implementacion
{
    public class PacienteService : IPacienteService
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
        public async Task<Paciente> Get(int id)
        {
            try
            {
                Paciente? find = new Paciente();

                find = await _dbContext.Pacientes
                    .Where(e => e.Id == id).FirstOrDefaultAsync(); 
                return find;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Paciente> Add(Paciente modelo)
        {
            try
            {
                _dbContext.Pacientes .Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo; 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Paciente modelo)
        {
            try
            {
                _dbContext.Pacientes.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Paciente modelo)
        {
            try
            {
                _dbContext.Pacientes.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

