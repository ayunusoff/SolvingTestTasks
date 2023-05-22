using AltPoint.Domain.Entities;
using AltPoint.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.Services
{
    public class ClientWithSpouseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public List<Child>? Сhildrens { get; set; }
        public Address LivingAddress { get; set; } = null!;
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
        public Client Spouce { get; set; }

        public ClientWithSpouseResponse(Client client, Client spouce)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Patronymic = client.Patronymic;
            DateOfBirth =client. DateOfBirth;
            Сhildrens = client.Сhildrens;
            LivingAddress = client.LivingAddress;
            PassportId = client.PassportId;
            Passport = client.Passport;
            Documents = client.Documents;
            RegAddress = client.RegAddress;
            Jobs = client.Jobs;
            CurWorkExp = client.CurWorkExp;
            TypeEducation = client.TypeEducation;
            MonIncome = client.MonIncome;
            MonExpenses = client.MonExpenses;
            Communications = client.Communications;
            Spouce = spouce;
        }
        
    }
}
