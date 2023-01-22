using System.ComponentModel.DataAnnotations;
namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
public class ClassroomStudentDto
{
    public int StudentId { get; set; }
    public int ClassroomId { get; set; }


}
