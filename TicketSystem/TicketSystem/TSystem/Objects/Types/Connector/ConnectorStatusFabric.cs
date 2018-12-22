using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.TSystem.Objects.Types.Connector.Concrete;

namespace TicketSystem.TSystem.Objects.Types.Connector
{
    static class ConnectorStatusFabric
    {
        public static ConnectorStatus haveUpdate = new HaveUpdate();
        public static ConnectorStatus needUpdate = new NeedUpdate();
        public static ConnectorStatus empty = new Empty();
    }
}
