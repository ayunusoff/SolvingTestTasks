using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Response
{
    public class ClientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime Dob { get; set; }
        public PassportResponse? Passport { get; set; }
        public AddressResponse? LivingAddress { get; set; }
        public AddressResponse? RegAddress { get; set; }
        public List<ChildResponse>? Children { get; set; }
        public List<JobResponse>? Jobs { get; set; }
        public TypeEducation? TypeEducation { get; set; }
        public double MonIncome { get; set; }
        public double MonExpenses { get; set; }
        public List<Guid>? Documents { get; set; }
        public List<CommunicationResponse>? Communications { get; set; }
    }
}
