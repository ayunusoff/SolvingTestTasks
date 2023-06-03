using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs
{
    public class MessageQueueDTO
    {
        public string EventName { get; set; } = null!;
        public ClientQueueMessageDTO client { get; set; } = null!;
    }
}
