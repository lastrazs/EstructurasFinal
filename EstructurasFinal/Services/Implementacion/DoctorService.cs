using Microsoft.EntityFrameworkCore;
using EstructurasFinal.Models;
using EstructurasFinal.Services.Cita;

namespace EstructurasFinal.Services.Implementacion
{
    public class DoctorService : IDoctorService
    {
        private EstructurasFinalContext _dbContext;

        public DoctorService(EstructurasFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Doctor>> GetList()
        {
            try
            {
                List<Doctor> lista = new List<Doctor>();
                lista = await _dbContext.Doctors.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<Doctor> Get(int Doctorid)
        {
            try
            {
                Doctor? find = new Doctor();

                find = await _dbContext.Doctors.Include(doctor => doctor.Status)
                    .Where(e => e.DoctorId == Doctorid).FirstOrDefaultAsync();
                return find;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Doctor> Add(Doctor modelo)
        {
            try
            {
                _dbContext.Doctors.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Doctor modelo)
        {
            try
            {
                _dbContext.Doctors.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Doctor modelo)
        {
            try
            {
                _dbContext.Doctors.Remove(modelo);
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
