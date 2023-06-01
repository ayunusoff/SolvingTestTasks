using AltPoint.Application.DTOs.Request;
using AltPoint.Application.DTOs.Response;
using AltPoint.Domain.Entities;
using AutoMapper;
using System.Reflection;

namespace AltPoint.Application.Mapping
{
    public class ClientMap : Profile
    {
        public ClientMap()
        {
            CreateMap<Address, AddressRequest>().ReverseMap();
            CreateMap<Child, ChildRequest>().ReverseMap();
            CreateMap<Job, JobRequest>().ReverseMap();
            CreateMap<Communication, CommunicationRequest>().ReverseMap();
            CreateMap<Passport, PassportRequest>().ReverseMap();
            CreateMap<Client, SpouseRequest>().ReverseMap();
            CreateMap<Client, ClientRequest>().ForMember(model => model.Spouse, option => option.Ignore()).ReverseMap();

            CreateMap<Address, AddressResponse>().ReverseMap();
            CreateMap<Child, ChildResponse>().ReverseMap();
            CreateMap<Job, JobResponse>().ReverseMap();
            CreateMap<Communication, CommunicationResponse>().ReverseMap();
            CreateMap<Passport, PassportResponse>().ReverseMap();
            CreateMap<Client, SpouseResponse>().ReverseMap();
            CreateMap<Client, ClientWithSpouseResponse>().ReverseMap();
            CreateMap<Client, ClientResponse>().ReverseMap();
            CreateMap<Page, ClientPaginationResponse>().ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.PageNum)).ReverseMap();

        }
    }
}
