namespace Domain.Entities;

public class Exam
{
    public int ExamId { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public List<Result> Results;
    
}

