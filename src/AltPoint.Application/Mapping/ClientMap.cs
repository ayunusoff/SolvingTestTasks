using AltPoint.Application.DTOs;
using AltPoint.Domain.Entities;
using AutoMapper;
using System.Reflection;

namespace AltPoint.Application.Mapping
{
    public class ClientMap : Profile
    {
        public ClientMap()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Child, ChildDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<Communication, CommunicationDTO>().ReverseMap();
            CreateMap<Passport, PassportDTO>().ReverseMap();
            CreateMap<Client, SpouseDTO>().ReverseMap();
            CreateMap<Client, ClientWithSpouseDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Page, ClientPaginationDTO>().ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.PageNum)).ReverseMap();
        }
    }
}
