namespace Domain.Dtos;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

public class StudentDto
{
    public int StudentId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateTime DOB  { get; set; }
    public string Sex { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfJoin { get; set; }
    public string ParentName { get; set; }
  

}
