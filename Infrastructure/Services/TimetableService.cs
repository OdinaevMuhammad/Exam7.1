namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
public class TimeTableService
{
    private DataContext _context;
    private IMapper _mapper;

    public TimeTableService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<Response<List<TimeTableDto>>> GetTimeTables()
    {
        var list = _mapper.Map<List<TimeTableDto>>(_context.TimeTables.ToList());


        return new Response<List<TimeTableDto>>(list);

    }

    public async Task<Response<TimeTableDto>> InsertTimeTable(TimeTableDto TimeTable)
    {

        try
        {
            var newTimeTable = _mapper.Map<TimeTable>(TimeTable);
        _context.TimeTables.Add(newTimeTable);

        await _context.SaveChangesAsync();
        TimeTable.TimeTableId = newTimeTable.TimeTableId;

        return new Response<TimeTableDto>(TimeTable);
        }
        catch (System.Exception ex)
        {
          return new Response<TimeTableDto>(HttpStatusCode.BadRequest, ex.Message);
        }
    }

    public async Task<Response<TimeTableDto>> UpdateTimeTable(TimeTableDto TimeTable)
    {
        var find = await _context.TimeTables.FindAsync(TimeTable.TimeTableId);
        find.Day = TimeTable.Day;
        find.Subject = TimeTable.Subject;
        find.TimeTableId = TimeTable.TimeTableId;
      

        await _context.SaveChangesAsync();

        return new Response<TimeTableDto>(TimeTable);
    }
    
    public async Task<Response<string>> DeleteTimeTable(int id)
    {
        var find = await _context.TimeTables.FindAsync(id);
        _context.TimeTables.Remove(find);
        await _context.SaveChangesAsync();
        if (find.TimeTableId > 0) return new Response<string>("TimeTable deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "TimeTable not found");
    }
}

