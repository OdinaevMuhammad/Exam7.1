using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(op => op.UseNpgsql(connection));

builder.Services.AddScoped<TimeTableService>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<ClassroomService>();
builder.Services.AddScoped<ClassroomStudentService>();
builder.Services.AddScoped<ResultService>();
builder.Services.AddScoped<ExamService>();

builder.Services.AddAutoMapper(typeof(ServiceProfile));






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
