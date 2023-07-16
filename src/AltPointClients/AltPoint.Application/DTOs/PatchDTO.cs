﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class PatchDTO
    {
        public string PropertyName { get; set; } = null!;
        public object? PropertyValue { get; set; }
    }
}
