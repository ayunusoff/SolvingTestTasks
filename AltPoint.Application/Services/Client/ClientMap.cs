using AltPoint.Domain.Entities;
using AutoMapper;

namespace AltPoint.Application.Services
{
    public class ClientMap : Profile
    {
        public ClientMap()
        {
            CreateMap<Client, GetAllClientWithParamRequest>();
        }
    }
}
