using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HikerPals.Models
{
    public class Hiker
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Trail Name")]
        [RegularExpression("[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Only alphabetical letters are allowed.")]
        [Display(Name = "Trail Name")]
        public string TrailName { get; set; }

        [Required(ErrorMessage = "Please enter your age.")]
        [Column("Age")]
        [Range(1, 120, ErrorMessage = "Please enter an age between 1 and 120.")]
        public int Age { get; set; }
        
        [Range(1, 50, ErrorMessage = "Please enter an average daily miles count between 1 and 50.")]
        [Display(Name = "Average Daily Miles")]
        public int AverageDailyMiles { get; set; }

        [Range(0, 99, ErrorMessage = "Please enter your years experience between 0 and 99.")]
        [Display(Name = "Years Experience")]
        public int YearsExperience { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        
        public int TrailId { get; set; }
        public Trail Trail { get; set; }

        public int PackId { get; set; }
        public pack pack { get; set; }
    }
}
