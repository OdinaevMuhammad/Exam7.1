using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SubjectServiceController
{
    private SubjectService _SubjectService;
    public SubjectServiceController(SubjectService subject)
    {
        _SubjectService = subject;
    }
    

    [HttpGet("Getsubject")]
    public async Task<Response<List<SubjectDto>>> Getsubjects()
    {
        return  await _SubjectService.GetSubjects();
    }
       [HttpPost("Insertsubject")]
    public async Task<Response<SubjectDto>> Insertsubject(SubjectDto subject)
    {
        return await _SubjectService.InsertSubject(subject);
    }

    [HttpPut("Updatesubject")]
    public async Task<Response<SubjectDto>> Updatesubject(SubjectDto subject)
    {
        return await _SubjectService.UpdateSubject(subject);
    }
    [HttpDelete("Deletesubject")]
    public async Task<Response<string>> Deletesubject(int id)
    {
        return await _SubjectService.DeleteSubject(id);
    }
}