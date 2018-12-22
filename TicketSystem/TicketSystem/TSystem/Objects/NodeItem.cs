using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.DS;
using TicketSystem.CommonComponents.WorkWithDataBase.SqlLite;

namespace TicketSystem.TSystem.Objects
{
    class NodeItem
    {
        private int id;
        private string name;
        private double value;

        public NodeItem(int id)
        {
            this.id = id;
            value = -1;
            load();
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public int getId()
        {
            return id;
        }

        private void load()
        {
            name = DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getNodeItemName(id)));
        }
    }
}
