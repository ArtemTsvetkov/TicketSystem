using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.DS;
using TicketSystem.CommonComponents.WorkWithDataBase.SqlLite;

namespace TicketSystem.TSystem.Objects
{
    class Connect
    {
        private int id;
        private Connector from;
        private Connector to;

        public Connect(int id)
        {
            this.id = id;
            load();
        }

        public int getId()
        {
            return id;
        }

        public Connector getFrom()
        {
            return from;
        }

        public Connector getTo()
        {
            return to;
        }

        private void load()
        {
            from = new Connector(DataSetConverter.fromDsToSingle.toInt.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getConnectFromId(id))));
            to = new Connector(DataSetConverter.fromDsToSingle.toInt.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getConnectToId(id))));
        }
    }
}
