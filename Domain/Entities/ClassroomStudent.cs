using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
public  class ClassroomStudent
{
   public int StudentId { get; set; }
  public int ClassroomId { get; set; }
  
  public Student Student;
  public Classroom Classroom;

}
