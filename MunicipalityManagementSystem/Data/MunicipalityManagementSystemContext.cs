using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Data
{
    public class MunicipalityManagementSystemContext : DbContext
    {
        public MunicipalityManagementSystemContext(DbContextOptions<MunicipalityManagementSystemContext> options)
            : base(options) { }

        public DbSet<CitizenManagement> Citizens { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<StaffManagement> Staffs { get; set; }
        public DbSet<Reports> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define primary key explicitly
            modelBuilder.Entity<CitizenManagement>().HasKey(c => c.CitizenID);
            modelBuilder.Entity<ServiceRequest>().HasKey(s => s.ServiceRequestID);
            modelBuilder.Entity<StaffManagement>().HasKey(s => s.StaffID);
            modelBuilder.Entity<Reports>().HasKey(r => r.ReportID);
        }
    }
}
