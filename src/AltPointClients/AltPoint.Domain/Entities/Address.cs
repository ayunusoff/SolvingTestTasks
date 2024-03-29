﻿using AltPoint.Domain.Common;

namespace AltPoint.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string House { get; set; } = null!;
        public string? Appartment { get; set; }

    }
}
