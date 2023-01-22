namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class StudentService
{
    private DataContext _context;
    private IMapper _mapper;

    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<StudentDto>>> GetStudents()
    {
        var list = _mapper.Map<List<StudentDto>>(_context.Students.ToList());


        return new Response<List<StudentDto>>(list);

    }

    public async Task<Response<StudentDto>> InsertStudent(StudentDto Student)
    {

       try
       {
         var newStudent = _mapper.Map<Student>(Student);
        _context.Students.Add(newStudent);

        await _context.SaveChangesAsync();
        Student.StudentId = newStudent.StudentId;

        return new Response<StudentDto>(Student);
       }
       catch (System.Exception ex)
       {
        return new Response<StudentDto>(HttpStatusCode.BadRequest, ex.Message);
       }
    }

    public async Task<Response<StudentDto>> UpdateStudent(StudentDto student)
    {
       try{
         var find = await _context.Students.FindAsync(student.StudentId);
        find.Name = student.Name;
        find.Address = student.Address;
        find.DateOfJoin = student.DateOfJoin;
        find.Email = student.Email;
        find.DOB = student.DOB;
        find.ParentName = student.ParentName;
        find.Password = student.Password;
        find.PhoneNumber = student.PhoneNumber;
        find.Sex = student.Sex;


        await _context.SaveChangesAsync();

        return new Response<StudentDto>(student);
       }
            catch (System.Exception ex)
       {
        return new Response<StudentDto>(HttpStatusCode.BadRequest, ex.Message);
       }
    }

    public async Task<Response<string>> DeleteStudent(int id)
    {
        var find = await _context.Students.FindAsync(id);
        _context.Students.Remove(find);
        await _context.SaveChangesAsync();
        if (find.StudentId > 0) return new Response<string>("Student deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "Student not found");
    }
}

