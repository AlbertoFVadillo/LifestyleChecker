using System.ComponentModel.DataAnnotations;

namespace LifestyleChecker.WebApp.Models
{
    public class QuestionsViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
        public bool Answer1 { get; set; }
        public bool Answer2 { get; set; }
        public bool Answer3 { get; set; }
        public string? ResultMessage { get; set; }
    }
}
