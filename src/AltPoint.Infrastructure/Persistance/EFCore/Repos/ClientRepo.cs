using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
using AltPoint.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;

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
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id)!;
        }

        public Client GetById(Guid id)
        {
            Client client = _context.Clients
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Сhildrens)
                .Include(c => c.Communications)
                .Include(c => c.Spouse)
                    .ThenInclude(s => s.Passport)
                .Include(c => c.Spouse)
                    .ThenInclude(s => s.LivingAddress)
                .Include(c => c.Spouse)
                    .ThenInclude(s => s.RegAddress)
                .Include(c => c.Spouse)
                    .ThenInclude(c => c.Communications)
                .AsSplitQuery()
                .FirstOrDefault(c => c.Id == id)!;

            return client;
        }

        public async Task<Page> GetClientsWithParams(List<string>? SortBy, List<string>? SortDir, int Limit, int Page, string? Search)
        {
            IQueryable<Client> clientsQuery = _context.Clients.AsNoTracking()
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Jobs!)
                    .ThenInclude(j => j.FactAddress)
                .Include(c => c.Jobs!)
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
            _context.Update(client);
            foreach(var cv in _context.Entry(client).CurrentValues.Properties)
            {
                Console.WriteLine(cv.PropertyInfo!.Name);
            }
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                Console.WriteLine(entry);
            }

            foreach (var entry in _context.ChangeTracker.Entries())
            {
                Console.WriteLine($"<--- {entry} ---- {entry.CurrentValues} ---->");
                foreach (var oValue in entry.References)
                    Console.WriteLine($"<--- {oValue.EntityEntry.State} ---- {oValue.CurrentValue} ---- {entry.Entity} ---->");
            }
        }
        public void PartialUpdate(Client client)
        {
            _context.Update(client);
        }
    }
}
