using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;

namespace AltPoint.Domain.Interfaces
{
    public interface IClientRepo : IRepo<Client>
    {
        Task<IEnumerable<Client>> GetClients(QueryParameters parameters);
        Task<IEnumerable<Client>> GetClientChild(Guid id);
        //Client GetByIdWithSpouse(Guid id);
    }
}
