using EstructurasFinal.Models;


namespace EstructurasFinal.Services.Cita
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetList();
        Task<Doctor> Get(int DoctorId);
        Task<Doctor> Add(Doctor modelo);
        Task<bool> Update(Doctor modelo);
        Task<bool> Delete(Doctor modelo);
      

    }
}
