namespace StudentsDashboard.Infrastructure.Authentication;

public class EmailSettings
{
    public const string SectionName = "Email";
    public string Host { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ServerName { get; set; } = string.Empty;
    public int Port { get; set; } = default;
}