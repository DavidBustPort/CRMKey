using Application.Common.Interfaces;
using Domain.Enums;
using System.Security.Claims;

namespace Web.Api
{
    public class UserContext(IHttpContextAccessor accessor) : IUserContext
    {
        private readonly ClaimsPrincipal? user = accessor.HttpContext?.User;

        public SiteMode Mode { get; set; }

        public int UserId => int.TryParse(user?.FindFirst("UserId")?.Value, out var id) ? id : 0;

        public int? RikId => int.TryParse(user?.FindFirst("RikId")?.Value, out var id) ? id : null;

        public int? SucursalId => int.TryParse(user?.FindFirst("SucursalId")?.Value, out var id) ? id : null;
    }
}
