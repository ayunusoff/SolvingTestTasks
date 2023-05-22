using AltPoint.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Domain.Interfaces
{
    public interface IChildRepo
    {
        Task<IEnumerable<Child>> GetClientChilds(Guid clientId);
    }
}
