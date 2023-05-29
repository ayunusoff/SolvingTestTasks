using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;

namespace AltPoint.Domain.Interfaces
{
    public interface IClientRepo : IRepo<Client>
    {
        Task<IEnumerable<Client>> GetClientsWithParams(List<string>? SortBy, string SortDir, int Limit, int Page, string? Search);
        //Client GetByIdWithSpouse(Guid id);
    }
}
