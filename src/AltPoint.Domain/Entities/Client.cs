using AltPoint.Domain.Common;
using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AltPoint.Domain.Entities
{
    public class Client : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime dob { get; set; }
        public ICollection<Child>? Сhildrens { get; set; }
        public Guid? SpouseId { get; set; }
        public Client? Spouse { get; set; }
        public Guid? LivingAddressId { get; set; }
        public Address LivingAddress { get; set;} = null!;
        public Passport Passport { get; set; } = null!;
        public ICollection<Document> Documents { get; set; } = null!;
        public Guid? RegAddressId { get; set; }
        public Address RegAddress { get; set; } = null!;
        public ICollection<Job>? Jobs { get; set; } 
        public int CurWorkExp { get; set; }
        public TypeEducation TypeEducation { get; set; }
        public double MonIncome { get; set; }
        public double MonExpenses { get; set; }
        public ICollection<Communication> Communications { get; set; } = null!;
    }
}
