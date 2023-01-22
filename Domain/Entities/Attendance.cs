using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class Attendance
    {
        [Key]
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        
        
        
        
        
        
    }

}