using System;
using System.Collections.Generic;

namespace EstructurasFinal.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Rh { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateTime? LastDate { get; set; }

    public DateTime? NextDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
