using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentServiceController
{
    private StudentService _StudentService;
    public StudentServiceController(StudentService student)
    {
        _StudentService = student;
    }
    

    [HttpGet("Getstudent")]
    public async Task<Response<List<StudentDto>>> Getstudents()
    {
        return  await _StudentService.GetStudents();
    }
       [HttpPost("Insertstudent")]
    public async Task<Response<StudentDto>> Insertstudent(StudentDto student)
    {
        return await _StudentService.InsertStudent(student);
    }

    [HttpPut("Updatestudent")]
    public async Task<Response<StudentDto>> Updatestudent(StudentDto student)
    {
        return await _StudentService.UpdateStudent(student);
    }
    [HttpDelete("Deletestudent")]
    public async Task<Response<string>> Deletestudent(int id)
    {
        return await _StudentService.DeleteStudent(id);
    }
}