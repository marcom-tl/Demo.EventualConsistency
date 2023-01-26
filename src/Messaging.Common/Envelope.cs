using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Messaging.Common
{
    public  class Envelope
    {
        public Envelope(IMessage message,string sender)
        {
            Id=Guid.NewGuid();
            CreatedAt = new DateTimeOffset(DateTime.UtcNow);
            Sender = sender;
            MessageVersion = message.Version;
            Type = message.Type;
            JsonContent = JsonConvert.SerializeObject(message);
        }

        public Guid Id { get;  }
        public string Sender { get;  }

        public string Type { get;  }

        public int MessageVersion { get;  }

        public DateTimeOffset CreatedAt { get; }

        public string JsonContent { get;  }

    }
}
