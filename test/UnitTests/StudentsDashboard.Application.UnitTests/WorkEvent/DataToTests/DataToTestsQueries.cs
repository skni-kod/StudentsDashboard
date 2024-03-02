namespace StudentsDashboard.Application.UnitTests.WorkEvent.DataToTests;

public static class DataToTestsQueries
{
    public static List<Domain.Entities.WorkEvent> DummyDataToAllEvents()
    {
        return new List<Domain.Entities.WorkEvent>
        {
            new Domain.Entities.WorkEvent
            {
                Id = 1,
                Id_Customer = 1,
                Location = 12.34,
                Title = "Test",
                From_Date = DateOnly.Parse("2022-12-12"),
                From_Time = TimeOnly.Parse("19:00:00"),
                To_Date = DateOnly.Parse("2022-12-13"),
                To_Time = TimeOnly.Parse("12:00:00")
            },
            new Domain.Entities.WorkEvent
            {
                Id = 2,
                Id_Customer = 1,
                Location = 12.34,
                Title = "Test1",
                From_Date = DateOnly.Parse("2023-12-12"),
                From_Time = TimeOnly.Parse("19:00:00"),
                To_Date = DateOnly.Parse("2023-12-13"),
                To_Time = TimeOnly.Parse("12:00:00")
            }
        };
    }

    public static List<Domain.Entities.WorkEvent> DummyDataToSpecificEcent()
    {
        return new List<Domain.Entities.WorkEvent>
        {
            new Domain.Entities.WorkEvent
            {
                Id = 2,
                Id_Customer = 1,
                Location = 12.34,
                Title = "Test1",
                From_Date = DateOnly.Parse("2023-12-12"),
                From_Time = TimeOnly.Parse("19:00:00"),
                To_Date = DateOnly.Parse("2023-12-13"),
                To_Time = TimeOnly.Parse("12:00:00")
            }
        };
    }
}