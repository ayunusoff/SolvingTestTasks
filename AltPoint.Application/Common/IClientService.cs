using AltPoint.Application.Services;
using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;

namespace AltPoint.Application.Common
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsWithParam(QueryParameters parameters);
        void DeleteClient(Guid id);
        GetClientResponse GetClient(Guid id);
    }
}
