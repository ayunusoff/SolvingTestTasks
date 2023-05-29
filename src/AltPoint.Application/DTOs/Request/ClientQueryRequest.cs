using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Request
{
    public class ClientQueryRequest
    {
        public List<string>? SortBy { get; set; }
        public string SortDir { get; set; } = "asc";
        public int Limit { get; set; }
        public int Page { get; set; }
        public string? Search { get; set; }
    }
}
