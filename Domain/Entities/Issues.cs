using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class Issues
    {
        [Key]
        public int IssueId { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public bool IsResolved { get; set; }
        
        
        
        
        
        
        
        
    }
}