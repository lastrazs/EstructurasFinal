namespace EstructurasFinal.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public string? Name { get; set; }

        public string? Specialty { get; set; }

        public TimeOnly? AvailableHour { get; set; }
    }
}
