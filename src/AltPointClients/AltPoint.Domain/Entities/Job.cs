using AltPoint.Domain.Common;
using AltPoint.Domain.Enums;

namespace AltPoint.Domain.Entities
{
    public class Job : AuditableEntity
    {
        public Guid Id { get; set; }
        public JobType? Type { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime? DateDismissal { get; set; }
        public double MonIncome { get; set; }
        public string? Tin { get; set; }
        public Guid FactAddressId { get; set; }
        public Address FactAddress { get; set; } = null!;
        public Guid JurAddressId { get; set; }
        public Address JurAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public Client Client { get; set; } = null!;
    }
}
