using AltPoint.Application.DTOs.Request;
using AltPoint.Application.DTOs.Response;
using AltPoint.Domain.Entities;
using AutoMapper;

namespace AltPoint.Application.Mapping
{
    public class ClientMap : Profile
    {
        public ClientMap()
        {
            CreateMap<ClientRequest, Client>();
            CreateMap<Client, ClientResponse>();
        }
    }
}
