namespace StudentsDashboard.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Events
    {
        public const int Id = 1;
        public const string Title = "Title";
        public static readonly DateOnly FromDate = DateOnly.Parse("2020-02-12");
        public static readonly TimeOnly FromTime = TimeOnly.Parse("20:00:00");
        public static readonly DateOnly ToDate = DateOnly.Parse("2021-02-12");
        public static readonly TimeOnly ToTime = TimeOnly.Parse("20:00:00");
        public const double Location = 123.45;
    }
}