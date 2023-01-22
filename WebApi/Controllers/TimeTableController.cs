using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeTableController
{
    private TimeTableService _TimeTableService;
    public TimeTableController(TimeTableService TimeTable)
    {
        _TimeTableService = TimeTable;
    }
    

    [HttpGet("GetTimeTable")]
    public async Task<Response<List<TimeTableDto>>> GetTimeTables()
    {
        return  await _TimeTableService.GetTimeTables();
    }
       [HttpPost("InsertTimeTable")]
    public async Task<Response<TimeTableDto>> InsertTimeTable(TimeTableDto TimeTable)
    {
        return await _TimeTableService.InsertTimeTable(TimeTable);
    }

    [HttpPut("UpdateTimeTable")]
    public async Task<Response<TimeTableDto>> UpdateTimeTable(TimeTableDto TimeTable)
    {
        return await _TimeTableService.UpdateTimeTable(TimeTable);
    }
    [HttpDelete("DeleteTimeTable")]
    public async Task<Response<string>> DeleteTimeTable(int id)
    {
        return await _TimeTableService.DeleteTimeTable(id);
    }
}