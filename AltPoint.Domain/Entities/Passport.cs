﻿using AltPoint.Domain.Common;
using System.Text.Json.Serialization;

namespace AltPoint.Domain.Entities
{
    public class Passport : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Series { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Giver { get; set; } = null!;
        public DateTime DateIssued { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
