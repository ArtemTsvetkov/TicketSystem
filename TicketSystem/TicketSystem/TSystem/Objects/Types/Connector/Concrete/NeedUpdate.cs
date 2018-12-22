using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.TSystem.Objects.Types.Connector.Concrete
{
    class NeedUpdate : ConnectorStatus
    {
        public string getStatus()
        {
            return "NeedUpdate";
        }
    }
}