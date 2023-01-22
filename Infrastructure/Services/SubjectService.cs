namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class SubjectService
{
    private DataContext _context;
    private IMapper _mapper;

    public SubjectService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<SubjectDto>>> GetSubjects()
    {
        var list = _mapper.Map<List<SubjectDto>>(_context.Subjects.ToList());


        return new Response<List<SubjectDto>>(list);

    }

    public async Task<Response<SubjectDto>> InsertSubject(SubjectDto subject)
    {

        try
        {
            var newSubject = _mapper.Map<Subject>(subject);
        _context.Subjects.Add(newSubject);

        await _context.SaveChangesAsync();
        subject.SubjectId = newSubject.SubjectId;

        return new Response<SubjectDto>(subject);
        }
        catch (System.Exception ex)
        {
          return new Response<SubjectDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<SubjectDto>> UpdateSubject(SubjectDto subject)
    {
        var find = await _context.Subjects.FindAsync(subject.SubjectId);
        find.Grade = subject.Grade;
        find.Description = subject.Description;
        find.Name = subject.Name;
    
        await _context.SaveChangesAsync();

        return new Response<SubjectDto>(subject);
    }
    
    public async Task<Response<string>> DeleteSubject(int id)
    {
        var find = await _context.Subjects.FindAsync(id);
        _context.Subjects.Remove(find);
        await _context.SaveChangesAsync();
        if (find.SubjectId > 0) return new Response<string>("Subject deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "Subject not found");
    }
}

