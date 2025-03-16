namespace HealthcareAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Soyad { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
