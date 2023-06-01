﻿using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
using AltPoint.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AltPoint.Infrastructure.Persistance.EFCore
{
    public class ClientRepo : IClientRepo
    {
        private readonly AltPointContext _context;

        public ClientRepo(AltPointContext context)
        {
            _context = context;
        }

        public async Task Add(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public IEnumerable<Client> GetAllSoftDeleted()
        {
            return _context.Clients.AsNoTracking()
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Spouse)
                .IgnoreQueryFilters().Where(c => c.IsDeleted).AsEnumerable();
        }


        public Client GetByIdWithoutTracking(Guid id)
        {
            return _context.Clients
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Spouse)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id)!;
        }

        public Client GetById(Guid id)
        {
            Client client = _context.Clients
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Spouse)
                .Include(c => c.Communications)
                .Include(c => c.Сhildrens)
                .AsSplitQuery()
                .FirstOrDefault(c => c.Id == id)!;

            if (client?.Spouse != null)
            { 
                _context.Entry(client.Spouse).Reference(s => s.Passport).Load();
                _context.Entry(client.Spouse).Reference(s => s.LivingAddress).Load();
                _context.Entry(client.Spouse).Reference(s => s.RegAddress).Load();
            }

            return client;
        }

        public async Task<Page> GetClientsWithParams(List<string>? SortBy, List<string>? SortDir, int Limit, int Page, string? Search)
        {
            IQueryable<Client> clientsQuery = _context.Clients.AsNoTracking()
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Jobs)
                    .ThenInclude(j => j.FactAddress)
                .Include(c => c.Jobs)
                    .ThenInclude(j => j.JurAddress);

            int count = await _context.Clients.CountAsync();

            if (Search != null)
                clientsQuery = clientsQuery.Search(Search);

            if (SortBy != null && SortDir != null)
                return new Page
                {
                    Limit = Limit,
                    PageNum = Page,
                    Total = count,
                    clients = clientsQuery.Skip(Limit * (Page - 1))
                        .Take(Limit).ToList().Sort(SortBy!, SortDir!)
                };

            return new Page
            {
                Limit = Limit,
                PageNum = Page,
                Total = count,
                clients = await clientsQuery.Skip(Limit * (Page - 1))
                    .Take(Limit).ToListAsync()
            };
        }

        public void Remove(Client client)
        {
            _context.Remove(client);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(Client client)
        {
            foreach (var entry in _context.ChangeTracker.Entries())
                Console.WriteLine(entry);

            _context.Attach(client);
            //foreach (var entry in _context.ChangeTracker.Entries())
            //  entry.State = EntityState.Modified;//Console.WriteLine(entry);
            //foreach (var entry in _context.ChangeTracker.Entries())
            //    if (entry. == EntityState.Added)
            //        entry.State = EntityState.Deleted;
            foreach (var refer in _context.Entry(client).References)
            { 
                var valeu = refer == null ? "null" : "Cur";
                Console.WriteLine($"curValue - {valeu}, {refer.EntityEntry.State}");
            }
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                Console.WriteLine($"<--- {entry} ---- {entry.CurrentValues} ---->");
                foreach (var oValue in entry.References)
                    Console.WriteLine($"<--- {oValue.EntityEntry.State} ---- {oValue.CurrentValue} ---- {entry.Entity} ---->");

            }
        }
        public async Task PartialUpdate()
        {

        }
    }
}
