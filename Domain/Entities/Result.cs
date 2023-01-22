namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Result
{
    [Key]
    public int ExamId { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int Marks { get; set; }
    
    
    public Exam Exam;
    public Student Student;
    public Subject Subject;
  
}

