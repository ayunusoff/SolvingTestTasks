using AltPoint.Domain.Entities;
using AltPoint.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Request
{
    public class SpouseRequest
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime dob { get; set; }
        public PassportRequest? Passport { get; set; }
        public AddressRequest? LivingAddress { get; set; }
        public AddressRequest? RegAddress { get; set; }
        public List<ChildRequest>? Children { get; set; }
        public List<JobRequest>? Jobs { get; set; }
        public TypeEducation? TypeEducation { get; set; }
        public double MonIncome { get; set; }
        public double MonExpenses { get; set; }
        public List<Guid>? Documents { get; set; }
        public List<CommunicationRequest>? Communications { get; set; }
    }
}
