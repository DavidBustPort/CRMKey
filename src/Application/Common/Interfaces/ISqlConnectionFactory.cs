using Domain.Enums;
using System.Data;

namespace Application.Common.Interfaces
{
    public interface ISqlConnectionFactory
    {
        Task<IDbConnection> CreateConnection(
            SiteMode? forceMode = SiteMode.sianweb,
            int? sucursalId = null);
    }
}
