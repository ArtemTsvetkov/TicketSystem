using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.DS;
using TicketSystem.CommonComponents.WorkWithDataBase.SqlLite;
using TicketSystem.TSystem.Exceptions;

namespace TicketSystem.TSystem.Objects
{
    class Node
    {
        private int id;
        private NodeItem[] items;
        private string name;

        internal NodeItem[] Items
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

        public Node(int id)
        {
            this.id = id;
            load();
        }

        public double getItemValue(int itemId)
        {
            for(int i=0; i<items.Length; i++)
            {
                if(items[i].getId()==itemId)
                {
                    if(items[i].Value==-1)
                    {
                        throw new ParentNodeMustBeCalcFirst();
                    }
                    return items[i].Value;
                }
            }
            return -1;
        }

        public string getName()
        {
            return name;
        }

        private void load()
        {
            name = DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getNodeName(id)));
            int[] nodeItemsId = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getNodeItems(id)));
            Items = new NodeItem[nodeItemsId.Length];
            for (int i = 0; i < nodeItemsId.Length; i++)
            {
                Items[i] = new NodeItem(nodeItemsId[i]);
            }
        }
    }
}
