using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;

namespace AltPoint.Domain.Interfaces
{
    public interface IClientRepo : IRepo<Client>
    {
        Task<Page> GetClientsWithParams(string SortBy, string SortDir, int Limit, int Page, string? Search);
        void PartialUpdate(Client client, Dictionary<string, object?> patches);
        Client GetByIdWithoutTracking(Guid id);

    }
}
