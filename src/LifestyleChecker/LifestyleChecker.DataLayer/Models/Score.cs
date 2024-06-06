using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LifestyleChecker.DataLayer.Models
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Score_ID
        {
            get;
            set;
        }

        [Required]
        [Column(TypeName = "int")]
        public int From
        {
            get;
            set;
        }

        [Column(TypeName = "int")]
        public int? To
        {
            get;
            set;
        }

        [Required]
        [Column(TypeName = "int")]
        public int Q1
        {
            get;
            set;
        }

        [Required]
        [Column(TypeName = "int")]
        public int Q2
        {
            get;
            set;
        }

        [Required]
        [Column(TypeName = "int")]
        public int Q3
        {
            get;
            set;
        }
    }
}
