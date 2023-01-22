using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController
{
    private ClassroomService _ClassroomService;
    public ClassroomController(ClassroomService classroom)
    {
        _ClassroomService = classroom;
    }
    

    [HttpGet("GetClassroom")]
    public async Task<Response<List<ClassroomDto>>> GetClassrooms()
    {
        return  await _ClassroomService.GetClassroom();
    }
       [HttpPost("InsertClassroom")]
    public async Task<Response<ClassroomDto>> InsertClassroom(ClassroomDto Classroom)
    {
        return await _ClassroomService.InsertClassroom(Classroom);
    }

    [HttpPut("UpdateClassroom")]
    public async Task<Response<ClassroomDto>> UpdateClassroom(ClassroomDto Classroom)
    {
        return await _ClassroomService.UpdateClassroom(Classroom);
    }
    [HttpDelete("DeleteClassroom")]
    public async Task<Response<string>> DeleteClassroom(int id)
    {
        return await _ClassroomService.DeleteClassroom(id);
    }
}