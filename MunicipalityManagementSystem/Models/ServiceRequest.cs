using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MunicipalityManagementSystem.Models
{
    public class ServiceRequest
    {
        [Key]
        public int ServiceRequestID { get; set; }
        
        [Required, ForeignKey("Citizen")]
        public int CitizenID { get; set; }

        [Required(ErrorMessage = "Service Request Type is required")]
        public string? ServiceRequestType { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string? Status { get; set; }


        public CitizenManagement Citizen { get; set; } //Navigation Property
    }
}
