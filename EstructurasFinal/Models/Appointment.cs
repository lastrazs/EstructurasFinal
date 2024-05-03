using System;
using System.Collections.Generic;

namespace EstructurasFinal.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public TimeOnly? AppointmentTime { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Paciente? Patient { get; set; }
}
