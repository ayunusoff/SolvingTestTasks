using AltPoint.Application.DTOs;

namespace AltPoint.Application.Common
{
    public interface IClientService
    {
        Task<ClientPaginationDTO> GetClientsWithParam(ClientQueryDTO parameters);
        Task DeleteClient(Guid id);
        ClientWithSpouseDTO GetClient(Guid id);
        Task<Guid> PostClient(ClientWithSpouseDTO client);
        Task PatchClient(Guid id, List<PatchDTO> patchDTOs);
        Task UpdateClient(ClientWithSpouseDTO client);
    }
}
