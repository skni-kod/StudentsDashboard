using StudentsDashboard.Application.WorkEvents.Queries.DTOs;
using StudentsDashboard.Domain.Entities;

namespace StudentsDashboard.Application.WorkEvents.Queries;

public static class Extensions
{
    public static GetEventsDto AsDto(this WorkEvent events)
    {
        return new GetEventsDto
        {
            Id = events.Id,
            Title = events.Title,
            FromDate = events.From_Date,
            FromTime = events.From_Time,
            ToDate = events.To_Date,
            ToTime = events.To_Time,
            Location = events.Location
        };
    }
}