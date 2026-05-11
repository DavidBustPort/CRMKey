using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Dashboard.Get
{
    public class GetDashboardQueryHandler : IApiRequestHandler<GetDashboardQuery, DashboardResponse>
    {
        public async Task<Result<DashboardResponse>> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            return Result<DashboardResponse>.Success(new DashboardResponse(), "al 100");
        }
    }
}
