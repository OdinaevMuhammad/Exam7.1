using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class TimeTable
{
    public int TimeTableId { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public string Subject { get; set; }
}



