using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class ClientPaginationDTO
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<ClientDTO> clients { get; set; } = null!;

    }
}
