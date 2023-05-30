using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;

namespace AltPoint.Domain.Interfaces
{
    public interface IClientRepo : IRepo<Client>
    {
        Task<IEnumerable<Client>> GetClientsWithParams(List<string>? SortBy, List<string>? SortDir, int Limit, int Page, string? Search);
    }
}
