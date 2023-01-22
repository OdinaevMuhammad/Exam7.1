namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class ResultService
{
    private DataContext _context;
    private IMapper _mapper;

    public ResultService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<ResultDto>>> GetResults()
    {
        var list = _mapper.Map<List<ResultDto>>(_context.Results.ToList());


        return new Response<List<ResultDto>>(list);

    }

    public async Task<Response<ResultDto>> Insertresult(ResultDto result)
    {

        try
        {
            var newresult = _mapper.Map<Result>(result);
            _context.Results.Add(newresult);

            await _context.SaveChangesAsync();
            result.ExamId = newresult.ExamId;

            return new Response<ResultDto>(result);
        }
        catch (System.Exception ex)
        {
            return new Response<ResultDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<ResultDto>> Updateresult(ResultDto result)
    {
        try
        {
            var find = await _context.Results.FindAsync(result.ExamId);
            find.Marks = result.Marks;
            find.StudentId = result.StudentId;
            find.SubjectId = result.SubjectId;

            await _context.SaveChangesAsync();

            return new Response<ResultDto>(result);
        }
        catch (System.Exception ex)
        {
            return new Response<ResultDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<string>> Deleteresult(int id)
    {
        var find = await _context.Results.FindAsync(id);
        _context.Results.Remove(find);
        await _context.SaveChangesAsync();
        if (find.ExamId > 0) return new Response<string>("result deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "result not found");
    }
}

