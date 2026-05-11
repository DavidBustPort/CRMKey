namespace Application.Common.Interfaces
{
    public interface IDatabaseResolverService
    {
        Task<string?> GetDbNameAsync(int sucursalId);
    }
}
