using Microsoft.EntityFrameworkCore;
using WebAPI_Practice.Models;

namespace WebAPI_Practice.DataContext
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
      public DbSet<PatientModel> Patients
      {
         get; set;
      }
      
      public DbSet<DoctorModel> Doctors 
      { 
        get; set; 
      }
   }
}
