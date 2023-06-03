using AltPoint.Application.DTOs;

namespace AltPoint.Application.Common
{
    public interface IClientService
    {
        Task<ClientPaginationDTO> GetAllClientsWithParam(ClientQueryDTO parameters);
        Task DeleteClient(Guid id);
        ClientWithSpouseDTO GetClient(Guid id);
        Task<Guid> PostClient(ClientWithSpouseDTO client);
        Task PatchClient(Guid id, ClientWithSpouseDTO client);
        Task UpdateClient(ClientWithSpouseDTO client);
    }
}
