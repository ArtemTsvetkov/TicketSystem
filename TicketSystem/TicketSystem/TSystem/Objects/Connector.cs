using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.TSystem.Objects.Types;
using TicketSystem.TSystem.Objects.Types.Connector;

namespace TicketSystem.TSystem.Objects
{
    class Connector
    {
        private int id;
        private ConnectorStatus status;

        public Connector(int id)
        {
            this.id = id;
            load();
        }

        public int getId()
        {
            return id;
        }

        internal ConnectorStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        private void load()
        {
            status = ConnectorStatusFabric.empty;
        }
    }
}
