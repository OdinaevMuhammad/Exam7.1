namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class ClassroomService
{
    private DataContext _context;
    private IMapper _mapper;

    public ClassroomService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<ClassroomDto>>> GetClassroom()
    {
        var list = _mapper.Map<List<ClassroomDto>>(_context.Classrooms.ToList());


        return new Response<List<ClassroomDto>>(list);

    }

    public async Task<Response<ClassroomDto>> InsertClassroom(ClassroomDto Classroom)
    {

        try
        {
            var newClassroom = _mapper.Map<Classroom>(Classroom);
        _context.Classrooms.Add(newClassroom);

        await _context.SaveChangesAsync();
        Classroom.ClassroomId = newClassroom.ClassroomId;

        return new Response<ClassroomDto>(Classroom);
        }
        catch (System.Exception ex)
        {
          return new Response<ClassroomDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<ClassroomDto>> UpdateClassroom(ClassroomDto classroom)
    {
        var find = await _context.Classrooms.FindAsync(classroom.ClassroomId);
        find.Grade = classroom.Grade;
        find.Section = classroom.Section;
        find.TeacherId = classroom.TeacherId;
    
        await _context.SaveChangesAsync();

        return new Response<ClassroomDto>(classroom);
    }
    
    public async Task<Response<string>> DeleteClassroom(int id)
    {
        var find = await _context.Classrooms.FindAsync(id);
        _context.Classrooms.Remove(find);
        await _context.SaveChangesAsync();
        if (find.ClassroomId > 0) return new Response<string>("Classroom deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "Classroom not found");
    }
}

