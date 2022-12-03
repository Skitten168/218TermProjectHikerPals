using System;
using System.ComponentModel.DataAnnotations;
namespace HikerPals.Models

{
    public class Trail
    {
        public int TrailId { get; set; }
        [Required(ErrorMessage ="Please enter a trail name")]
        [RegularExpression("[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Only alphabetical letters are allowed.")]
        [StringLength(50, MinimumLength = 5)]
        public string TName { get; set; }
        public double Distance { get; set; }
     /*   [Required]
        public int HikerId { get; set; }
        public Hiker Hiker { get; set; }*/
    }
}
