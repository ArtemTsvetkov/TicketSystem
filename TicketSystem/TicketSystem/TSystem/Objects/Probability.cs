using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.DS;
using TicketSystem.CommonComponents.WorkWithDataBase.SqlLite;

namespace TicketSystem.TSystem.Objects
{
    class Probability
    {
        private int id;
        private int currentItemId;
        private int[] items;
        private double value;

        public Probability(int id)
        {
            this.id = id;
            load();
        }

        public int getId()
        {
            return id;
        }

        public int CurrentItemId
        {
            get
            {
                return currentItemId;
            }

            set
            {
                currentItemId = value;
            }
        }

        public int[] Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
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

        private void load()
        {
            Items = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getProbabilityitems(id)));
            CurrentItemId = DataSetConverter.fromDsToSingle.toInt.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getProbabilityCurrentItemId(id)));
            Value = double.Parse(DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getProbabilityValue(id))).
                Replace('.',','));
        }
    }
}
