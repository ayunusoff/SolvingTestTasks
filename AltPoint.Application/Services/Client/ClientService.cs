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
        //public readonly IMapper _mapper;
        public ClientService(IClientRepo clientRepo)//, IMapper mapper)
        {
            _clientRepo = clientRepo;
            //_mapper = mapper;

        }
        public GetClientResponse GetClient(Guid id)
        {
            var client = _clientRepo.GetById(id);
            return new GetClientResponse();
        }
        public async Task<IEnumerable<Client>> GetAllClientsWithParam(QueryParameters parameters)
        {
            return await _clientRepo.GetClients(parameters);// _mapper.Map<List<Client>>(_clientRepo.GetClients(parameters));
        }
        public void DeleteClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new NullReferenceException($"client с ID:{id} не существует!");

            client.Fire(DateTime.UtcNow);
        }
    }
}
