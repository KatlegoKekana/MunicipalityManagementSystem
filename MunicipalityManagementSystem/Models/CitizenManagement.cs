using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class CitizenManagement
    {
        [Key]
        public int CitizenID { get; set; } //PRIMARY KEY

        [Required(ErrorMessage = "Please enter your full name")]
        public string? FullName { get; set; } //Allow nulls temporarily

        [Required(ErrorMessage = "Please enter your address")]
        public string? Address { get; set; }

        [Required, Phone(ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Required, EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
