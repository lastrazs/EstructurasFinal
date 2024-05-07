using EstructurasFinal.Models;

namespace EstructurasFinal.Services.Cita
{
    public interface ICitaService
    {
        Task<List<Appointment>> GetList();
        Task<Appointment> Get(int idCita);
        Task<Appointment> Add(Appointment modelo);
        Task<bool> Update(Appointment modelo);
        Task<bool> Delete(Appointment modelo);

    }
}
 