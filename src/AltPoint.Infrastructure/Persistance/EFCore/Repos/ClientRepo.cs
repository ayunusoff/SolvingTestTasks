using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
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
            return _context.Clients.FirstOrDefault(c => c.Id == id)!;
        }

        public async Task<IEnumerable<Client>> GetClientsWithParams(List<string>? SortBy, string SortDir, int Limit, int Page, string? Search)
        {
            IEnumerable<Client> clients = await GetAll();
            return clients;
            //return parameters.SortDir == "asc" ? clients.OrderBy(c => c.GetType().GetProperty(SortedBy!))
            //    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            //    .Take(parameters.PageSize) : clients.OrderByDescending(c => c.GetType().GetProperty(parameters.SortedBy!))
            //    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            //    .Take(parameters.PageSize);
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
