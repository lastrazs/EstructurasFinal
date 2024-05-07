using AutoMapper;
using EstructurasFinal.DTOs;
using EstructurasFinal.Models;
using System.Globalization;

namespace EstructurasFinal.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Appointments
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(des =>
                des.PatientName,
                opt => opt.MapFrom(origin => origin.Patient.Name))
                .ForMember(des => 
                des.DoctorName,
                opt => opt.MapFrom(origin => origin.Doctor.Name));
            CreateMap<AppointmentDTO, Appointment>();


            #endregion
            #region Paciente
            CreateMap<Paciente, PacienteDTO>();
            CreateMap<PacienteDTO, Paciente>();
            #endregion
            #region Doctor
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<Doctor, DoctorDTO>();
            #endregion


        }

    }
}
