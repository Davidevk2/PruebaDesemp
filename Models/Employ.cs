using System.ComponentModel.DataAnnotations;

namespace PruebaDesemp.Models
{
    public class Employ{
        [Key]  
        public int Id { get; set; }
        [Required]
        public string? Names {get; set;}
        
        public string? LastNames {get; set;}
        [Required]
        public string? Email {get; set;}
        [Required]
        public DateTime BirthDate {get; set;}
        [Required]
        public string? ProfilePicture {get; set;}
        [Required]
        public string? Cv {get; set;}
        [Required]
        public string? Gender {get; set;}
        [Required]
        public string? Phone {get; set;}
        [Required]
        public string? Address {get; set;}
        [Required]
        public string? CivilStatus {get; set;}
        [Required]
        public double Salary {get; set;}
        [Required]
        public string? About {get; set;}
        [Required]
        public string? AcademiTitle {get; set;}
         [Required]
        public string? Languages {get; set;}
         [Required]
        public string? Area {get; set;}

    }
}