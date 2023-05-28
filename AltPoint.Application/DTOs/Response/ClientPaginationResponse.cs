using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Response
{
    public class ClientPaginationResponse
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<ClientResponse> clients { get; set; }

    }
}
