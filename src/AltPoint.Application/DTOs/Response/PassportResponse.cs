using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Response
{
    public class PassportResponse
    {
        public Guid Id { get; set; }

        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Giver { get; set; } = null!;
        public DateTime? DateIssued { get; set; }
    }
}
