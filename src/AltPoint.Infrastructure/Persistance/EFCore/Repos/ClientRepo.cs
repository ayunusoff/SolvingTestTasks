using AltPoint.Domain.Common;
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
            throw new NotImplementedException();
        }

        public Client GetById(Guid id)
        {
            Client client = _context.Clients
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Passport)
                .Include(c => c.Spouse)
                .FirstOrDefault(c => c.Id == id)!;

            if (client.Spouse != null)
            { 
                _context.Entry(client.Spouse).Reference(s => s.Passport).Load();
                _context.Entry(client.Spouse).Reference(s => s.LivingAddress).Load();
                _context.Entry(client.Spouse).Reference(s => s.RegAddress).Load();
            }

            return client;
        }

        public async Task<IEnumerable<Client>> GetClientsWithParams(List<string>? SortBy, List<string>? SortDir, int Limit, int Page, string? Search)
        {
            IQueryable<Client> clientsQuery = _context.Clients.AsNoTracking()
                .Skip(Limit * (Page - 1))
                .Take(Limit);
            if (Search != null)
                clientsQuery.Search(Search);
            if (SortBy != null && SortDir != null)
                return clientsQuery.Sort(SortBy!, SortDir!);

            return await clientsQuery.ToListAsync();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Client obj)
        {
            throw new NotImplementedException();
        }
    }
}
