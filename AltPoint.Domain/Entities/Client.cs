using AltPoint.Domain.Common;
using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AltPoint.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public List<Child>? Сhildrens { get; set; }
        public Address LivingAddress { get; set;} = null!;
        public Guid PassportId { get; set; }
        public Passport Passport { get; set; } = null!;
        public List<Document> Documents { get; set; } = null!;
        public Address RegAddress { get; set; } = null!;
        public List<Job>? Jobs { get; set; } 

        public int CurWorkExp { get; set; }
        public TypeEducation TypeEducation { get; set; }
        public int MonIncome { get; set; }
        public int MonExpenses { get; set; }
        public List<Communication> Communications { get; set; } = null!;
        public Client(Guid id, string name, string surname, string patronymic, DateTime dateOfBirth, List<Child>? сhildrens, Address livingAddress, Guid passportId, Passport passport, List<Document> documents, Address regAddress, List<Job>? jobs, int curWorkExp, TypeEducation typeEducation, int monIncome, int monExpenses, List<Communication> communications)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            Сhildrens = сhildrens;
            LivingAddress = livingAddress;
            PassportId = passportId;
            Passport = passport;
            Documents = documents;
            RegAddress = regAddress;
            Jobs = jobs;
            CurWorkExp = curWorkExp;
            TypeEducation = typeEducation;
            MonIncome = monIncome;
            MonExpenses = monExpenses;
            Communications = communications;
        }
        public void Fire(DateTime deleteDate)
        {
            IsDeleted = true;
            DeletedAt = deleteDate;
        }
    }
}
