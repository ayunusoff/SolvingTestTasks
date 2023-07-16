using AltPoint.Domain.Common;
using AltPoint.Domain.Enums;

namespace AltPoint.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime dob { get; set; }
        public IList<Child>? Сhildrens { get; set; }
        public Guid? SpouseId { get; set; }
        public Client? Spouse { get; set; }
        public Guid? LivingAddressId { get; set; }
        public Address LivingAddress { get; set;} = null!;
        public Passport Passport { get; set; } = null!;
        public IList<Document> Documents { get; set; } = null!;
        public Guid? RegAddressId { get; set; }
        public Address RegAddress { get; set; } = null!;
        public IList<Job>? Jobs { get; set; } 
        public int CurWorkExp { get; set; }
        public TypeEducation TypeEducation { get; set; }
        public double MonIncome { get; set; }
        public double MonExpenses { get; set; }
        public IList<Communication> Communications { get; set; } = null!;
    }
}
