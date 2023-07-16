using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class ClientQueryDTO
    {
        public string SortBy { get; set; } = null!;
        public string SortDir { get; set; } = null!;
        public int Limit { get; set; }
        public int Page { get; set; }
        public string? Search { get; set; }
    }
}
