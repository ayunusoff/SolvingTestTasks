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
            CreateMap<Client, SpouseRequest>().ReverseMap();//.ForSourceMember(model => model.SpouseId, option => option.Ignore()).ForMember(model => model.Spouse, option => option.Ignore())
            CreateMap<Client, ClientRequest>().ForMember(model => model.Spouse, option => option.Ignore()).ReverseMap();//.ForMember(model => model.SpouseId, option => option.Ignore());
        }
    }
}
