using AltPoint.Application.Common;
using AltPoint.Domain.Entities;
using AltPoint.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepo _childRepo;

        public ChildService(IChildRepo childRepo)
        {
            _childRepo = childRepo;
        }
        
        public async Task<IEnumerable<Child>> GetClientChilds(Guid id)
        {
            
            return await _childRepo.GetClientChilds(id);
        }
    }
}
