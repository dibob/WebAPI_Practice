using System.ComponentModel.DataAnnotations;

namespace WebAPI_Practice.Models
{
   public class DoctorModel
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public string CRM { get; set; }
      public bool IsActive { get; set; }
      public DateTime CreatedIn { get; set; } = DateTime.Now.ToLocalTime();
      public DateTime ModifiedIn { get; set; } = DateTime.Now.ToLocalTime();
    }
}
