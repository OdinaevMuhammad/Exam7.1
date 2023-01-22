namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class ClassroomStudentService
{
    private DataContext _context;
    private IMapper _mapper;

    public ClassroomStudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<ClassroomStudentDto>>> GetClassroomStudents()
    {
        var list = _mapper.Map<List<ClassroomStudentDto>>(_context.ClassroomStudents.ToList());


        return new Response<List<ClassroomStudentDto>>(list);

    }

    public async Task<Response<ClassroomStudentDto>> InsertClassroomStudent(ClassroomStudentDto classroomstudent)
    {

        try
        {
            var newClassroomStudent = _mapper.Map<ClassroomStudent>(classroomstudent);
            _context.ClassroomStudents.Add(newClassroomStudent);

            await _context.SaveChangesAsync();
            classroomstudent.ClassroomId = newClassroomStudent.ClassroomId;
            classroomstudent.StudentId = newClassroomStudent.StudentId;


            return new Response<ClassroomStudentDto>(classroomstudent);
        }
        catch (System.Exception ex)
        {
            return new Response<ClassroomStudentDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<ClassroomStudentDto>> UpdateClassroomStudent(ClassroomStudentDto classroomstudent)
    {
        try
        {
            var find = await _context.ClassroomStudents.FindAsync(classroomstudent.ClassroomId);
            find.ClassroomId = classroomstudent.ClassroomId;
            find.StudentId = classroomstudent.StudentId;
            
            await _context.SaveChangesAsync();

            return new Response<ClassroomStudentDto>(classroomstudent);
        }
        catch (System.Exception ex)
        {
            return new Response<ClassroomStudentDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<string>> DeleteClassroomStudent(int id)
    {
        var find = await _context.ClassroomStudents.FindAsync(id);
        _context.ClassroomStudents.Remove(find);
        await _context.SaveChangesAsync();
        if (find.ClassroomId > 0 && find.StudentId>0) return new Response<string>("ClassroomStudent deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "ClassroomStudent not found");
    }
}

