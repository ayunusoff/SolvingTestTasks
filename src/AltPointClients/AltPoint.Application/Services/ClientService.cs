using AltPoint.Application.Common;
using AltPoint.Domain.Interfaces;
using FluentValidation;
using AutoMapper;
using AltPoint.Application.Validations;
using AltPoint.Domain.Entities;
using AltPoint.Application.DTOs;

namespace AltPoint.Application.Services
{
    public class ClientService : IClientService
    {
        public readonly IClientRepo _clientRepo;
        public readonly IValidator<ClientDTO> _validator;
        public readonly IValidator<ClientWithSpouseDTO> _validatorClientWithSpouse;
        public readonly IMapper _mapper;
        public ClientService(IClientRepo clientRepo, IValidator<ClientDTO> validator, IValidator<ClientWithSpouseDTO> validatorClientWithSpouse, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _validator = validator;
            _validatorClientWithSpouse = validatorClientWithSpouse;
            _mapper = mapper;
        }

        public ClientWithSpouseDTO GetClient(Guid id)
        {
            Client client = _clientRepo.GetById(id);

            if (client is null)
                throw new ArgumentNullException();

            return _mapper.Map<ClientWithSpouseDTO>(client);
        }

        public async Task<Guid> PostClient(ClientWithSpouseDTO clientRequest)
        {
            await _validatorClientWithSpouse.ValidateAndThrowAsync(clientRequest);
            Client client = _mapper.Map<Client>(clientRequest);

            await _clientRepo.Add(client);
            await _clientRepo.SaveChanges();

            return client.Id;
        }

        public async Task<ClientPaginationDTO> GetClientsWithParam(ClientQueryDTO parameters)
        {
            var clientsPage = await _clientRepo.GetClientsWithParams(parameters.SortBy, parameters.SortDir, parameters.Limit, parameters.Page, parameters.Search);
            var clientResponse = _mapper.Map<ClientPaginationDTO>(clientsPage);

            return clientResponse;
        }

        public async Task DeleteClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new ArgumentNullException();

            _clientRepo.Remove(client);

            await _clientRepo.SaveChanges();
        }

        public async Task PatchClient(Guid id, List<PatchDTO> patchDTOs)
        {
            Client client = _clientRepo.GetById(id);
            _clientRepo.PartialUpdate(client, patchDTOs.ToDictionary(k => k.PropertyName, v => v.PropertyValue));

            await _clientRepo.SaveChanges();
        }

        public async Task UpdateClient(ClientWithSpouseDTO clientRequest)
        {
            await _validatorClientWithSpouse.ValidateAndThrowAsync(clientRequest);

            Client client = _mapper.Map<Client>(clientRequest);
            
            _clientRepo.Update(client);
            await _clientRepo.SaveChanges();
        }
    }
}
