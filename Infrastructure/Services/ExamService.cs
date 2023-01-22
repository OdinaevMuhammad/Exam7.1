namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class ExamService
{
    private DataContext _context;
    private IMapper _mapper;

    public ExamService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<ExamDto>>> GetExams()
    {
        var list = _mapper.Map<List<ExamDto>>(_context.Exams.ToList());


        return new Response<List<ExamDto>>(list);

    }

    public async Task<Response<ExamDto>> InsertExam(ExamDto exam)
    {

        try
        {
            var newExam = _mapper.Map<Exam>(exam);
            _context.Exams.Add(newExam);

            await _context.SaveChangesAsync();
            exam.ExamId = newExam.ExamId;

            return new Response<ExamDto>(exam);
        }
        catch (System.Exception ex)
        {
            return new Response<ExamDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<ExamDto>> UpdateExam(ExamDto exam)
    {
        try
        {
            var find = await _context.Exams.FindAsync(exam.ExamId);
            find.Date = exam.Date;
            find.Name = exam.Name;
            
            await _context.SaveChangesAsync();

            return new Response<ExamDto>(exam);
        }
        catch (System.Exception ex)
        {
            return new Response<ExamDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteExam(int id)
    {
        var find = await _context.Exams.FindAsync(id);
        _context.Exams.Remove(find);
        await _context.SaveChangesAsync();
        if (find.ExamId > 0) return new Response<string>("Exam deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "Exam not found");
    }
}

