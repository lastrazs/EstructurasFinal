using EstructurasFinal.Models;


namespace EstructurasFinal.Services.Cita
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetList();
        Task<Paciente> Get(int idPaciente);
        Task<Paciente> Add(Paciente modelo);
        Task<bool> Update(Paciente modelo);
        Task<bool> Delete(Paciente modelo);

    }
}
