using AltPoint.Domain.Entities;
using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class JobDTO
    {
        public Guid Id { get; set; }
        public JobType? Type { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime? DateDismissal { get; set; }
        public double MonIncome { get; set; }
        public string? Tin { get; set; }
        public Guid FactAddressId { get; set; }
        public AddressDTO? FactAddress { get; set; }
        public Guid JurAddressId { get; set; }
        public AddressDTO? JurAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
