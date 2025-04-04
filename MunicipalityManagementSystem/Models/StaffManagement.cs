using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class StaffManagement
    {
        [Key]
        public int StaffID { get; set; } // Primary Key

        [Required(ErrorMessage = "Full Name is required")]
        public string? FullName { get; set; } //Allow nulls temporarily

        [Required(ErrorMessage = "Position is required")]
        public string? Position { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string? Department { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string? Email { get; set; }

        [Required, Phone(ErrorMessage = "Invalid Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
