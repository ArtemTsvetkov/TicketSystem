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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
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

        public int getId()
        {
            return id;
        }

        public int[] getProbabilitiesIndexes(List<Probability> probabilitys)
        {
            List<int> resList = new List<int>();
            for (int i=0; i<probabilitys.Count; i++)
            {
                if(probabilitys.ElementAt(i).CurrentItemId==id)
                {
                    resList.Add(i);
                }
            }
            int[] result = new int[resList.Count];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = resList.ElementAt(i);
            }

            return result;
        }

        private void load()
        {
            Name = DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getNodeItemName(id)));
        }
    }
}
