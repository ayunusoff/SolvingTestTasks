using AltPoint.Application.DTOs.Response;
using AltPoint.Domain.Entities;
using AltPoint.Domain.Enums;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Request
{
    [AutoMap(typeof(Client))]
    public class ClientRequest
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime dob { get; set; }
        public PassportRequest? Passport { get; set; }
        public AddressRequest? LivingAddress { get; set; }
        public AddressRequest? RegAddress { get; set; }
        
        public SpouseRequest? Spouse { get; set; }

        public List<ChildRequest>? Children { get; set; }
        public List<JobRequest>? Jobs { get; set; }
        public TypeEducation? TypeEducation { get; set; }
        public double MonIncome { get; set; }
        public double MonExpences { get; set; }
        public List<Guid>? DocumentIds { get; set; }
        public List<CommunicationRequest>? Communications { get; set; }
    }
}
