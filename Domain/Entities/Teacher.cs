namespace Domain.Entities;

public class Teacher
{
    public int TeacherId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateTime DOB  { get; set; }
    public string Sex { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfJoin { get; set; }
    public List<Classroom> Classrooms;
}