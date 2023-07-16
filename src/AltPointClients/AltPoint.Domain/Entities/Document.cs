using AltPoint.Domain.Common;

namespace AltPoint.Domain.Entities
{
    public class Document : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; } = null!;
    }
}
