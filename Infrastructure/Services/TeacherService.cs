namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class TeacherService
{
    private DataContext _context;
    private IMapper _mapper;

    public TeacherService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<TeacherDto>>> GetTeachers()
    {
        var list = _mapper.Map<List<TeacherDto>>(_context.Teachers.ToList());


        return new Response<List<TeacherDto>>(list);

    }

    public async Task<Response<TeacherDto>> InsertTeacher(TeacherDto Teacher)
    {

        try
        {
            var newTeacher = _mapper.Map<Teacher>(Teacher);
        _context.Teachers.Add(newTeacher);

        await _context.SaveChangesAsync();
        Teacher.TeacherId = newTeacher.TeacherId;

        return new Response<TeacherDto>(Teacher);
        }
        catch (System.Exception ex)
        {
          return new Response<TeacherDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<TeacherDto>> UpdateTeacher(TeacherDto Teacher)
    {
        var find = await _context.Teachers.FindAsync(Teacher.TeacherId);
        find.Name = Teacher.Name;
        find.Address = Teacher.Address;
        find.DateOfJoin = Teacher.DateOfJoin;
        find.Email = Teacher.Email;
        find.DOB = Teacher.DOB;
        find.Password = Teacher.Password;
        find.PhoneNumber = Teacher.PhoneNumber;
        find.Sex = Teacher.Sex;


        await _context.SaveChangesAsync();

        return new Response<TeacherDto>(Teacher);
    }
    
    public async Task<Response<string>> DeleteTeacher(int id)
    {
        var find = await _context.Teachers.FindAsync(id);
        _context.Teachers.Remove(find);
        await _context.SaveChangesAsync();
        if (find.TeacherId > 0) return new Response<string>("Teacher deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "Teacher not found");
    }
}

