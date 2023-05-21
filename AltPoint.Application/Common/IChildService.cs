using AltPoint.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.Common
{
    public interface IChildService
    {
        Task<IEnumerable<Child>> GetClientChild(Guid id);
    }
}
