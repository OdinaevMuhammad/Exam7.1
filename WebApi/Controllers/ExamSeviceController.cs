using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController
{
    private ExamService _ExamService;
    public ExamController(ExamService exam)
    {
        _ExamService = exam;
    }
    

    [HttpGet("Getexam")]
    public async Task<Response<List<ExamDto>>> Getexams()
    {
        return  await _ExamService.GetExams();
    }
       [HttpPost("Insertexam")]
    public async Task<Response<ExamDto>> Insertexam(ExamDto exam)
    {
        return await _ExamService.InsertExam(exam);
    }

    [HttpPut("Updateexam")]
    public async Task<Response<ExamDto>> Updateexam(ExamDto exam)
    {
        return await _ExamService.UpdateExam(exam);
    }
    [HttpDelete("Deleteexam")]
    public async Task<Response<string>> Deleteexam(int id)
    {
        return await _ExamService.DeleteExam(id);
    }
}