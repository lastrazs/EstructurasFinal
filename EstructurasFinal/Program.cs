using EstructurasFinal.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System.Security;

using EstructurasFinal.Services.Cita;
using EstructurasFinal.Services.Implementacion;

using AutoMapper;
using EstructurasFinal.DTOs;
using EstructurasFinal.Utilities;
using Microsoft.AspNetCore.Builder;

namespace EstructurasFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<EstructurasFinalContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
            });

            builder.Services.AddScoped<ICitaService, CitaServices>();

            builder.Services.AddScoped<IDoctorService, DoctorService>();

            builder.Services.AddScoped<IPacienteService, PacienteService>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("newPoliticy", app =>
                {
                    app.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            #region PETICIONES API REST
            //<---------------------------CitasRoutes------------------------------------>
            app.MapGet("/citas/lista", async (
                ICitaService _citaservices,
                IMapper _mapper
                ) =>
                {
                    var AppointmentsList = await _citaservices.GetList();
                    var AppointmentsListDTO = _mapper.Map<List<AppointmentDTO>>(AppointmentsList);

                    if (AppointmentsList.Count > 0)
                    {
                        return Results.Ok(AppointmentsListDTO);
                    } else
                        return Results.NotFound();

                });
            //<---------------------------PacienteRoutes------------------------------------>
            app.MapGet("/paciente/lista", async (
                IPacienteService _pacienteservices,
                IMapper _mapper
                ) =>
                    {
                        var pacienteList = await _pacienteservices.GetList();
                        var pacienteListDTO = _mapper.Map<List<PacienteDTO>>(pacienteList);

                        if (pacienteListDTO.Count > 0)
                        {
                            return Results.Ok(pacienteListDTO);
                        } else
                            return Results.NotFound();
                    });

            app.MapPost("/paciente/save", async (
                PacienteDTO model,
                IPacienteService _pacienteservices,
                IMapper _mapper
                ) =>
                    {
                        var _paciente = _mapper.Map<Paciente>(model);
                        var _pacienteCreate = await _pacienteservices.Add(_paciente);

                        if (_pacienteCreate.Id != 0)
                        {
                            return Results.Ok(_mapper.Map<PacienteDTO>(_pacienteCreate));
                        } else
                            return Results.StatusCode(StatusCodes.Status500InternalServerError);
                    });
            app.MapPut("/paciente/update/{idPaciente}", async (
                int idPaciente,
                PacienteDTO model,
                IPacienteService _pacienteservices,
                IMapper _mapper
                ) =>
            {
                var _find = await _pacienteservices.Get(idPaciente);
                if (_find is null) return Results.NotFound();

                var _paciente = _mapper.Map<Paciente>(model);

                _find.Id = model.Id;
                _find.Name = model.Name;
                _find.Age = model.Age;
                _find.CorreoElectronico = model.CorreoElectronico;
                _find.Telefono = model.Telefono;
                _find.Rh = model.Rh;
                _find.LastDate = model.LastDate;

                var res = await _pacienteservices.Update(_find);

                if (res)
                    return Results.Ok(_mapper.Map<PacienteDTO>(_find));
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            });

            app.MapDelete("/paciente/delete/{idPaciente}", async (
                int idPaciente,
                IPacienteService _pacienteservices
                ) =>
            {
                var _find = await _pacienteservices.Get(idPaciente);

                if (_find is null) return Results.NotFound();

                var res = await _pacienteservices.Delete(_find);

                if (res)
                    return Results.Ok();
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            });
            //<---------------------------DoctoresRoutes------------------------------------>

            app.MapGet("/doctor/lista", async (
                IDoctorService _doctorservices,
                IMapper _mapper
                ) =>
            {
                var doctorList = await _doctorservices.GetList();
                var doctorListDTO = _mapper.Map<List<DoctorDTO>>(doctorList);

                if (doctorListDTO.Count > 0)
                {
                    return Results.Ok(doctorListDTO);
                }
                else
                    return Results.NotFound();
            });
            app.MapPost("/doctor/save", async (
                DoctorDTO model,
                IDoctorService _DoctorServices,
                IMapper _mapper
                ) =>
            {
                var _Doctor = _mapper.Map<Doctor>(model);
                var _DoctorCreate = await _DoctorServices.Add(_Doctor);

                if (_DoctorCreate.DoctorId != 0)
                {
                    return Results.Ok(_mapper.Map<DoctorDTO>(_DoctorCreate));
                }
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            });
            app.MapPut("/doctor/update/{doctorId}", async (
                int doctorId,
                DoctorDTO model,
                IDoctorService _DoctorServices,
                IMapper _mapper
                ) =>
            {
                var _find = await _DoctorServices.Get(doctorId);
                if (_find is null) return Results.NotFound();

                var _doctor = _mapper.Map<Doctor>(model);

                _find.DoctorId = model.DoctorId;
                _find.Name = model.Name;
                _find.Specialty = model.Specialty;
                _find.AvailableHour = model.AvailableHour;
                _find.Status = model.Status;

                var res = await _DoctorServices.Update(_find);

                if (res)
                    return Results.Ok(_mapper.Map<DoctorDTO>(_find));
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            });

            app.MapDelete("/doctor/delete/{DoctorId}", async (
                int doctorId,
                IDoctorService _DoctorServices
                ) =>
            {
                var _find = await _DoctorServices.Get(doctorId);

                if (_find is null) return Results.NotFound();

                var res = await _DoctorServices.Delete(_find);

                if (res)
                    return Results.Ok();
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            });
               
            #endregion
            app.UseAuthorization();

            app.UseCors("newPoliticy");

            app.MapControllers();

            app.Run();
        }
    }
}
