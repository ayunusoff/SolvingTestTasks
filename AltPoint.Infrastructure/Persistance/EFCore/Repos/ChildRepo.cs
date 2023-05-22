using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Infrastructure.Persistance.EFCore.Repos
{
    public class ChildRepo : IChildRepo
    {
        private readonly AltPointContext _context;

        public ChildRepo(AltPointContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Child>> GetClientChilds(Guid clientId)
        {
            var parent = _context.Clients.FirstOrDefault(p => p.Id == clientId);
            var childs = await _context.Childs.AsNoTracking().Where(c => c.Parents.Contains(parent!)).ToListAsync();
            return childs;
        }
    }
}
