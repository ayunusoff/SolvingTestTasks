using AltPoint.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public Guid Id { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Appartment { get; set; }

        public Guid ClientRegAdressId { get; set; }

        public Client ClientRegAdress { get; set; } = null!;
        public Guid ClientLivingAddressId { get; set; }

        public Client ClientLivingAddress { get; set; } = null!;

    }
}
