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

        public void Add(Client obj)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetClients(QueryParameters parameters)
        {
            var clients = await GetAll();
            return parameters.SortDir == "asc" ? clients.OrderBy(c => c.GetType().GetProperty(parameters.SortedBy!))
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize) : clients.OrderByDescending(c => c.GetType().GetProperty(parameters.SortedBy!))
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);
        }


        //public Client GetSpouse(Guid id)
        //{
        //    var client
        //    var spouse 
        //}  

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Client obj)
        {
            throw new NotImplementedException();
        }
    }
}
