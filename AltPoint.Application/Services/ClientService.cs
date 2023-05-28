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
        public ClientResponse GetClient(Guid id) //TODO
        {
            var client = _clientRepo.GetById(id);
            if (client is null)
                throw new NullReferenceException($"client с ID:{id} не существует!");
            return new ClientResponse();
        }
        public async Task<Guid> PostClient(ClientRequest clientRequest)
        {
            await _validator.ValidateAndThrowAsync(clientRequest);
            Client client = _mapper.Map<Client>(clientRequest);
            _clientRepo.Add(client);
            return Guid.NewGuid();
        }
        public async Task<ClientPaginationResponse> GetAllClientsWithParam(ClientQueryRequest parameters) //TODO
        {
            ClientPaginationResponse response = new ClientPaginationResponse();
            await _clientRepo.GetClientsWithParams(parameters.SortBy, parameters.SortDir, parameters.Limit, parameters.Page, parameters.Search);
            return response;
        }
        public void DeleteClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new NullReferenceException($"client с ID:{id} не существует!");

            client.Delete(DateTime.UtcNow);
        }
    }
}
