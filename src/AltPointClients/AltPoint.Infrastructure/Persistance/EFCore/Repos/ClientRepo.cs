using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
using AltPoint.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

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
                .FirstOrDefault(c => c.Id == id)!;

            return client;
        }

        public async Task<Page> GetClientsWithParams(string SortBy, string SortDir, int Limit, int Page, string? Search)
        {
            IQueryable<Client> clientsQuery = _context.Clients.AsNoTracking()
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Сhildrens)
                .Include(c => c.Communications)
                .Include(c => c.Jobs!)
                    .ThenInclude(j => j.FactAddress)
                .Include(c => c.Jobs!)
                    .ThenInclude(j => j.JurAddress)
                .OrderBy(SortBy, SortDir)
                .Skip(Limit * (Page - 1))
                .Take(Limit);

            if (Search != null)
                clientsQuery = clientsQuery.Search(Search);

            return new Page
            {
                Limit = Limit,
                PageNum = Page,
                Total = await _context.Clients.CountAsync(),
                clients = clientsQuery
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

        public void Update(Client client)
        {
            _context.Update(client);
        }
        public void PartialUpdate(Client client, Dictionary<string, object?> patches)
        {
            foreach (var item in patches)
            {
                var prop = _context.Entry(client).Member(item.Key);
                if (item.Value is null && prop is ReferenceEntry referenceEntry)
                    _context.Remove(referenceEntry.TargetEntry!);
                else
                    prop.CurrentValue = ((JsonElement)item.Value!).Deserialize(prop.CurrentValue!.GetType());
            }
        }
    }
}
