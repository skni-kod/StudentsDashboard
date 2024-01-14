using System.Security.Claims;

namespace StudentsDashboard.Application.Persistance;

public interface IUserContextGetIdService
{
    int? GetUserId { get; }
    ClaimsPrincipal User { get; }
}