using AltPoint.Application.Services;
using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;

namespace AltPoint.Application.Common
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsWithParam(QueryParameters parameters);
        Task DeleteClient(Guid id);
        GetClientResponse GetClient(Guid id);
        Task<ClientWithSpouseResponse> GetClientWithSpouse(Guid id);
        Task AddClient(Client client);


    }
}
