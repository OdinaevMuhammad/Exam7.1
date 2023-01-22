namespace Domain.Entities;

public class Subject
{
    public int SubjectId { get; set; }
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Description { get; set; }
    public List<Result> Results;


}