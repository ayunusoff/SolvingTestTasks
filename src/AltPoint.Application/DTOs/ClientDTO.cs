using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime Dob { get; set; }
        public PassportDTO? Passport { get; set; }
        public AddressDTO? LivingAddress { get; set; }
        public AddressDTO? RegAddress { get; set; }
        public List<ChildDTO>? Children { get; set; }
        public List<JobDTO>? Jobs { get; set; }
        public TypeEducation? TypeEducation { get; set; }
        public double MonIncome { get; set; }
        public double MonExpenses { get; set; }
        public List<Guid>? Documents { get; set; }
        public List<CommunicationDTO>? Communications { get; set; }
    }
}
