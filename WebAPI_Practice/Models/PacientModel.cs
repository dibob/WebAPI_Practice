 using System.ComponentModel.DataAnnotations;
using WebAPI_Practice.Enums;

namespace WebAPI_Practice.Models
{
   public class PatientModel
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public GenderEnum Gender { get; set; }
      public HealthCareEnum HealthCare { get; set; }
      public bool IsActive { get; set; }
      public DateTime CreatedIn { get; set; } = DateTime.Now.ToLocalTime();
      public DateTime ModifiedIn { get; set; } = DateTime.Now.ToLocalTime();
    }
}
