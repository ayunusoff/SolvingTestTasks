using AltPoint.Application.DTOs.Request;
using AltPoint.Application.DTOs.Response;

namespace AltPoint.Application.Common
{
    public interface IClientService
    {
        Task<ClientPaginationResponse> GetAllClientsWithParam(ClientQueryRequest parameters);
        Task DeleteClient(Guid id);
        ClientWithSpouseResponse GetClient(Guid id);
        Task<Guid> PostClient(ClientRequest client);
        Task PatchClient(ClientRequest client);
        Task UpdateClient(Guid id, ClientRequest client);
    }
}
