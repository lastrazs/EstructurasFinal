using Microsoft.EntityFrameworkCore;
using EstructurasFinal.Models;
using EstructurasFinal.Services.Cita;

namespace EstructurasFinal.Services.Implementacion
{
    public class CitaServices : ICitaService
    {
    
        private EstructurasFinalContext _dbContext;

            public CitaServices(EstructurasFinalContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<List<Appointment>> GetList()
            {
                try
                {
                    List<Appointment> lista = new List<Appointment>();
                    lista = await _dbContext.Appointments.ToListAsync();
                    return lista;
                }
                 catch (Exception ex)
                {
                throw ex;
            }
        }
        public async Task<Appointment> Get(int AppointmentId)
        {
            try
            {
                Appointment? find = new Appointment();
                find = await _dbContext.Appointments
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .FirstOrDefaultAsync(a => a.AppointmentId == AppointmentId);
                return find;
            }
            catch (Exception ex)
            {
                {
                    throw ex;
                }
            }
        } 

        public async Task<Appointment> Add(Appointment modelo)
        {
                try
                {
                    _dbContext.Appointments.Add(modelo);
                    await    _dbContext.SaveChangesAsync();
                    return modelo;
                }
                catch (Exception ex)
                {
                throw ex;
                }
        }
        public async Task<bool> Update(Appointment modelo)
        {
            try
            {
                _dbContext.Appointments.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Appointment modelo)
        {
            try
            {
                _dbContext.Appointments.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
