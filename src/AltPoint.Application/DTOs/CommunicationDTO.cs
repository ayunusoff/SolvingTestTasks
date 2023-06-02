using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class CommunicationDTO
    {
        public Guid Id { get; set; }
        public CommunicationType Type { get; set; }
        public string Value { get; set; } = null!;
    }
}
