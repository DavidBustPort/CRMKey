using Application.Common.Interfaces;

namespace Application.Features.Dashboard.Get
{
    public record GetDashboardQuery(
        int StartMonth,
        int StartYear,
        int EndMonth,
        int EndYear,
        string? SucursalesId,
        int? RikId) : IApiRequest<DashboardResponse>;
}
