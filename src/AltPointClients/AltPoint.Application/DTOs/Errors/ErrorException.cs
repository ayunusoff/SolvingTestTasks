using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Errors
{
    public class ErrorException
    {
        public string field { get; set; } = null!;

        public string rule { get; set; } = null!;

        public string message { get; set; } = null!;
    }
}
