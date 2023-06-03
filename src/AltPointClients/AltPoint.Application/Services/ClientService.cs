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
        public readonly IProducer _producer;
        public ClientService(IClientRepo clientRepo, IValidator<ClientDTO> validator, IValidator<ClientWithSpouseDTO> validatorClientWithSpouse, IMapper mapper, IProducer producer)
        {
            _clientRepo = clientRepo;
            _validator = validator;
            _validatorClientWithSpouse = validatorClientWithSpouse;
            _mapper = mapper;
            _producer = producer;
        }

        public ClientWithSpouseDTO GetClient(Guid id)
        {
            Client client = _clientRepo.GetById(id);

            if (client is null)
                throw new ArgumentNullException($"client с ID:{id} не найден!");

            return _mapper.Map<ClientWithSpouseDTO>(client);
        }

        public async Task<Guid> PostClient(ClientWithSpouseDTO clientRequest)
        {
            await _validatorClientWithSpouse.ValidateAndThrowAsync(clientRequest);
            Client client = _mapper.Map<Client>(clientRequest);

            await _clientRepo.Add(client);

            if (client.Spouse != null)
            { 
                client.SpouseId = client.Spouse.Id;
                await _clientRepo.Add(client.Spouse!);
            }

            await _clientRepo.SaveChanges();

            MessageQueueDTO clientMessage = new MessageQueueDTO
            {
                EventName = "Create",
                client = _mapper.Map<ClientQueueMessageDTO>(client)
            };

            _producer.SendClientMessage(clientMessage);

            return client.Id;
        }

        public async Task<ClientPaginationDTO> GetAllClientsWithParam(ClientQueryDTO parameters)
        {
            var sortBy = parameters.SortQuery?.Select(sq => sq.SortBy).ToList();
            var sortDir = parameters.SortQuery?.Select(sq => sq.SortDir).ToList();

            var clients = await _clientRepo.GetClientsWithParams(sortBy, sortDir, parameters.Limit, parameters.Page, parameters.Search);
            var clientResponse = _mapper.Map<ClientPaginationDTO>(clients);

            return clientResponse;
        }

        public async Task DeleteClient(Guid id)
        {
            var client = _clientRepo.GetById(id);

            if (client is null)
                throw new ArgumentNullException($"client с ID:{id} не найден!");

            _clientRepo.Remove(client);
            await _clientRepo.SaveChanges();

            MessageQueueDTO clientMessage = new MessageQueueDTO
            {
                EventName = "Delete",
                client = _mapper.Map<ClientQueueMessageDTO>(client)
            };
            _producer.SendClientMessage(clientMessage);

        }

        public async Task PatchClient(Guid id, ClientWithSpouseDTO clientRequest) // TODO
        {
            await _validatorClientWithSpouse.ValidateAndThrowAsync(clientRequest);

            Client client = _clientRepo.GetById(id);
            _clientRepo.PartialUpdate(client);

            client = _mapper.Map<Client>(clientRequest);//

            await _clientRepo.SaveChanges();
        }

        public async Task UpdateClient(ClientWithSpouseDTO clientRequest) // TODO
        {
            //Client client = _clientRepo.GetById(clientRequest.Id);

            await _validatorClientWithSpouse.ValidateAndThrowAsync(clientRequest);

            Client client = _mapper.Map<Client>(clientRequest);
            
            _clientRepo.Update(client);
            await _clientRepo.SaveChanges();

            MessageQueueDTO clientMessage = new MessageQueueDTO
            {
                EventName = "Update",
                client = _mapper.Map<ClientQueueMessageDTO>(client)
            };

            _producer.SendClientMessage(clientMessage);
        }
    }
}
