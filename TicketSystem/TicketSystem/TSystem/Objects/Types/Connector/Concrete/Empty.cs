using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.TSystem.Objects.Types.Connector.Concrete
{
    class Empty : ConnectorStatus
    {
        public string getStatus()
        {
            return "Empty";
        }
    }
}