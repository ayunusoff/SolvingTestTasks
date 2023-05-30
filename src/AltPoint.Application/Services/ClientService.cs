using AltPoint.Application.Common;
using AltPoint.Application.DTOs.Request;
using AltPoint.Application.DTOs.Response;
using AltPoint.Domain.Interfaces;
using FluentValidation;
using AutoMapper;
using AltPoint.Application.Validations;
using AltPoint.Domain.Entities;

namespace AltPoint.Application.Services
{
    public class ClientService : IClientService
    {
        public readonly IClientRepo _clientRepo;
        public readonly IValidator<ClientRequest> _validator;
        public readonly IMapper _mapper;
        public ClientService(IClientRepo clientRepo, IValidator<ClientRequest> validator, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _validator = validator;
            _mapper = mapper;

        }
        public ClientResponse GetClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new NullReferenceException($"client с ID:{id} не существует!");

            return _mapper.Map<ClientResponse>(client);
        }
        public async Task<Guid> PostClient(ClientRequest clientRequest)
        {
            await _validator.ValidateAndThrowAsync(clientRequest);
            Client client = _mapper.Map<Client>(clientRequest);

            await _clientRepo.Add(client);
            if (client.Spouse != null)
            { 
                client.SpouseId = client.Spouse.Id;
                await _clientRepo.Add(client.Spouse!);
            }

            await _clientRepo.SaveChanges();
            return client.Id;
        }
        public async Task<ClientPaginationResponse> GetAllClientsWithParam(ClientQueryRequest parameters) //TODO
        {
            ClientPaginationResponse response = new ClientPaginationResponse();
            var sortBy = parameters.SortQuery?.Select(sq => sq.SortBy).ToList();
            var sortDir = parameters.SortQuery?.Select(sq => sq.SortDir).ToList();

            var clients = await _clientRepo.GetClientsWithParams(sortBy, sortDir, parameters.Limit, parameters.Page, parameters.Search);
            var clientResponse = _mapper.Map<List<ClientResponse>>(clients);
            ClientPaginationResponse paginationResponse = new ClientPaginationResponse
            {
                Limit = parameters.Limit,
                Page = parameters.Page,
                Total = 100, // TODO
                clients = clientResponse,
            };
            return paginationResponse;
        }
        public void DeleteClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new NullReferenceException($"client с ID:{id} не существует!");

            _clientRepo.Remove(id);
        }
    }
}
