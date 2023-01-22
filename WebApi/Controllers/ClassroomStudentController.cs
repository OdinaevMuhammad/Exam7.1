using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomStudentController
{
    private ClassroomStudentService _ClassroomStudentService;
    public ClassroomStudentController(ClassroomStudentService classroom)
    {
        _ClassroomStudentService = classroom;
    }
    

    [HttpGet("GetClassroomStudent")]
    public async Task<Response<List<ClassroomStudentDto>>> GetClassrooms()
    {
        return  await _ClassroomStudentService.GetClassroomStudents();
    }
       [HttpPost("InsertClassroomStudent")]
    public async Task<Response<ClassroomStudentDto>> InsertClassroom(ClassroomStudentDto classroom)
    {
        return await _ClassroomStudentService.InsertClassroomStudent(classroom);
    }

    [HttpPut("UpdateClassroomStudent")]
    public async Task<Response<ClassroomStudentDto>> UpdateClassroom(ClassroomStudentDto classroom)
    {
        return await _ClassroomStudentService.UpdateClassroomStudent(classroom);
    }
    [HttpDelete("DeleteClassroomStudent")]
    public async Task<Response<string>> DeleteClassroom(int id)
    {
        return await _ClassroomStudentService.DeleteClassroomStudent(id);
    }
}