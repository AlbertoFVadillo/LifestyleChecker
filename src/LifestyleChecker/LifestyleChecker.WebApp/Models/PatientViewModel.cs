using System.ComponentModel.DataAnnotations;

namespace LifestyleChecker.WebApp.Models
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "Please enter NHS Number")]
        public string NHSNumber { get; set; }

        [Required(ErrorMessage = "Please enter Surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
