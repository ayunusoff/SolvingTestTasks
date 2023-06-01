using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Errors
{
    public class ValidationError
    {
        public int status { get; set; }
        public ErrorCode code { get; set; }
        public List<ValidationExceptions> exceptions { get; set; } = null!;
    }
}
