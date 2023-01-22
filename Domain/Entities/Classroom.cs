namespace Domain.Entities;

public class Classroom
{
    public int ClassroomId { get; set; }
    public string Section { get; set; }
    public int Grade { get; set; }
    public int TeacherId { get; set; }
    
    public Teacher Teacher;
    public List<ClassroomStudent> ClassroomStudents;
}