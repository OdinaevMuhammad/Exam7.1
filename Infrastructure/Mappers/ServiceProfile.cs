using System;
namespace Infrastructure.Mappers;
using AutoMapper;
using Domain.Entities;
using Domain.Dtos;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
       
    CreateMap<Classroom, ClassroomDto>().ReverseMap();
   CreateMap<ClassroomStudent, ClassroomStudentDto>().ReverseMap();
      CreateMap<Student, StudentDto>().ReverseMap();
      CreateMap<Teacher, TeacherDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
          CreateMap<Issues, IssuesDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
              CreateMap<Result, ResultDto>().ReverseMap();

              CreateMap<TimeTable, TimeTableDto>().ReverseMap();

    }
}