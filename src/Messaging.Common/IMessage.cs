using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Common
{
    public interface IMessage
    {
        int Version { get;  }

        string Type { get;  }
    }
}
