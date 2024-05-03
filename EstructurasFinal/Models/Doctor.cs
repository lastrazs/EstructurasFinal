using System;
using System.Collections.Generic;

namespace EstructurasFinal.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Specialty { get; set; }

    public string? WorkSchedule { get; set; }

    public TimeOnly? AvailableHour { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
