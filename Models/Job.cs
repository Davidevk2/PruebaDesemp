using System.ComponentModel.DataAnnotations;

namespace PruebaDesemp.Models
{
    public class Job{

        [Key]
        public int Id { get; set; }
        [Required]
        public string? NameCompany { get; set; }
        [Required]
        public string? LogoCompany { get; set; }
        [Required]
        public string? OfferTitle { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public int Positions { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? Languages { get; set; }


    }
}