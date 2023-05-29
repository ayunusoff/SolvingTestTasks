using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Request
{
    public class PassportRequest
    {
        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Giver { get; set; } = null!;
        public DateTime? DateIssued { get; set; }
    }
}
