using AltPoint.Domain.Enums;

namespace AltPoint.Domain.Entities
{
    public class Communication
    {
        public Guid Id { get; set; }
        public CommunicationType Type { get; set; }
        public string Value { get; set; } = null!;
        public Client Client { get; set; } = null!;
    }
}
