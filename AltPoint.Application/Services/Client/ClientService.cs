using AltPoint.Application.Common;
using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
//using AutoMapper;

namespace AltPoint.Application.Services
{
    public class ClientService : IClientService
    {
        public readonly IClientRepo _clientRepo;
        public readonly IChildRepo _childRepo;
        //public readonly IMapper _mapper;
        public ClientService(IClientRepo clientRepo, IChildRepo childRepo)
        {
            _clientRepo = clientRepo;
            _childRepo = childRepo;

        }

        public async Task AddClient(Client client)
        {
            if (client == null) throw new ArgumentNullException("client null");
            await _clientRepo.Add(client);
        }

        public GetClientResponse GetClient(Guid id)
        {
            var client = _clientRepo.GetById(id);
            return new GetClientResponse();
        }

        public async Task<ClientWithSpouseResponse> GetClientWithSpouse(Guid id)
        {
            var client = _clientRepo.GetById(id);
            var childs = await _childRepo.GetClientChilds(id);

            if (childs == null)
                throw new NullReferenceException($"client с ID:{id} волк-одиночка!");

            var spouse = childs.FirstOrDefault()!.Parents.Where(p => p.Id != id).First();

            return new ClientWithSpouseResponse(client, spouse);
        }

        public async Task<IEnumerable<Client>> GetAllClientsWithParam(QueryParameters parameters)
        {
            return await _clientRepo.GetClients(parameters);
        }

        public async Task DeleteClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new NullReferenceException($"client с ID:{id} не существует!");

            client.Fire(DateTime.UtcNow);
            await _clientRepo.SaveChanges();
        }
    }
}
