using AltPoint.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Domain.Entities
{
    public class Document : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; } = null!;
    }
}
