namespace EstructurasFinal.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Age { get; set; }

        public string? Rh { get; set; }

        public string? Telefono { get; set; }

        public string? CorreoElectronico { get; set; }

        public DateTime? LastDate { get; set; } = default(DateTime?);
    }
}
