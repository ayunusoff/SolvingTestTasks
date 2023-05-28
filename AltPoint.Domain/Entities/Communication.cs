using AltPoint.Domain.Enums;
using System.Text.Json.Serialization;

namespace AltPoint.Domain.Entities
{
    public class Communication
    {
        public Guid Id { get; set; }
        public CommunicationType Type { get; set; }
        public string Value { get; set; } = null!;
        public Guid ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
