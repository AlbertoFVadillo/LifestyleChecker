namespace LifestyleChecker.Framework.Models
{
    public class PatientResponse
    {
        public bool IsAuthenticated { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string? Message { get; set; }
    }
}
