using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherServiceController
{
    private TeacherService _TeacherService;
    public TeacherServiceController(TeacherService teacher)
    {
        _TeacherService = teacher;
    }
    

    [HttpGet("Getteacher")]
    public async Task<Response<List<TeacherDto>>> Getteachers()
    {
        return  await _TeacherService.GetTeachers();
    }
       [HttpPost("Insertteacher")]
    public async Task<Response<TeacherDto>> Insertteacher(TeacherDto teacher)
    {
        return await _TeacherService.InsertTeacher(teacher);
    }

    [HttpPut("Updateteacher")]
    public async Task<Response<TeacherDto>> Updateteacher(TeacherDto teacher)
    {
        return await _TeacherService.UpdateTeacher(teacher);
    }
    [HttpDelete("Deleteteacher")]
    public async Task<Response<string>> Deleteteacher(int id)
    {
        return await _TeacherService.DeleteTeacher(id);
    }
}