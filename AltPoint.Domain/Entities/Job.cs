using AltPoint.Domain.Common;
using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Domain.Entities
{
    public class Job : AuditableEntity
    {
        public Guid Id { get; set; }
        public JobType Type { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime DateDismissal { get; set; }
        public int MonIncome { get; set; }
        public string? Tin { get; set; }
        public Guid FactAddressId { get; set; }

        public Address? FactAddress { get; set; }
        public Guid JurAddressId { get; set; }

        public Address? JurAddress { get; set; }
        public string? PhoneNumber { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; } = null!;
    }
}
