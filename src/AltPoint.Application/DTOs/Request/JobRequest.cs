using AltPoint.Application.DTOs.Response;
using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Request
{
    public class JobRequest
    {
        public JobType? Type { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime? DateDismissal { get; set; }
        public double MonIncome { get; set; }
        public string Tin { get; set; } = null!;
        public Guid FactAddressId { get; set; }
        public AddressRequest FactAddress { get; set; } = null!;
        public Guid JurAddressId { get; set; }
        public AddressRequest JurAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}
