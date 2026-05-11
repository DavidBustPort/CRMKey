using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface IUserContext
    {
        SiteMode Mode { get; set; }
        int UserId { get; }
        int? RikId { get; }
        public int? SucursalId { get; }
    }
}
