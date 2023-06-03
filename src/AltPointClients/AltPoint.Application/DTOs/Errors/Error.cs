using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Errors
{
    public class Error
    {
        public int status { get; set; }
        public ErrorCode code { get; set; }
    }
}
