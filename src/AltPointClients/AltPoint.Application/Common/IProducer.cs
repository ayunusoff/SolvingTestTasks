using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.Common
{
    public interface IProducer
    {
        void SendClientMessage<T>(T message) where T : class;
    }
}
