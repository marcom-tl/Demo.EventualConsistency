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
        //public Envelope(IMessage message,string sender)
        //{
        //    Id=Guid.NewGuid();
        //    CreatedAt = new DateTimeOffset(DateTime.UtcNow);
        //    Sender = sender;
        //    MessageVersion = message.Version;
        //    Type = message.Type;
        //    JsonContent = JsonConvert.SerializeObject(message);
        //}

        public Envelope()
        {
            
        }
        public Guid Id { get; set; }
        public string Sender { get; set; }

        public string Type { get; set; }

        public int MessageVersion { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string JsonContent { get; set; }

        public  static Envelope CreateEnvelope(IMessage message, string sender)
        {
            Envelope envelope = new Envelope()
            { 
                Id = Guid.NewGuid(),
                CreatedAt = new DateTimeOffset(DateTime.UtcNow),
                Sender = sender,
                MessageVersion = message.Version,
                Type = message.Type,
                JsonContent = JsonConvert.SerializeObject(message),
            };
            return envelope;
        }

    }
}
