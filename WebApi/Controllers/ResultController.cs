using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultController
{
    private ResultService _ResultService;
    public ResultController(ResultService classroom)
    {
        _ResultService = classroom;
    }
    

    [HttpGet("GetClassroom")]
    public async Task<Response<List<ResultDto>>> GetClassrooms()
    {
        return  await _ResultService.GetResults();
    }
       [HttpPost("InsertClassroom")]
    public async Task<Response<ResultDto>> InsertClassroom(ResultDto classroom)
    {
        return await _ResultService.Insertresult(classroom);
    }

    [HttpPut("UpdateClassroom")]
    public async Task<Response<ResultDto>> UpdateClassroom(ResultDto classroom)
    {
        return await _ResultService.Updateresult(classroom);
    }
    [HttpDelete("DeleteClassroom")]
    public async Task<Response<string>> DeleteClassroom(int id)
    {
        return await _ResultService.Deleteresult(id);
    }
}