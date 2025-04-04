using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityManagementSystem.Models
{
    public class Reports
    {
        [Key]
        public int ReportID { get; set; } // Primary Key

        [Required, ForeignKey("Citizen")]
        public int CitizenID { get; set; } // Foreign Key

        [Required(ErrorMessage = "Report Type is required")]
        public string? ReportType { get; set; }

        [Required(ErrorMessage = "Details are required")]
        public string? Details { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        public string? Status { get; set; } = "Under Review";


        public CitizenManagement Citizen { get; set; } // Navigation Property
    }
}
