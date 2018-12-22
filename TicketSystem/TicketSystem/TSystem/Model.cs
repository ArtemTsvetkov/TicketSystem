using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.DS;
using TicketSystem.CommonComponents.WorkWithDataBase.SqlLite;
using TicketSystem.CommonComponents.WorkWithFiles.Save;
using TicketSystem.TSystem.Exceptions;
using TicketSystem.TSystem.Objects;
using TicketSystem.TSystem.Workers;

namespace TicketSystem.TSystem
{
    class Model
    {
        private Node[] nodes;
        private List<Probability> probabilitys;

        public Model()
        {
            load();
        }

        public Node[] getNodes()
        {
            return nodes;
        }

        public void calcNodesItemsValues()
        {
            List<int> recalcNodes = new List<int>();
            for (int i = 0; i < nodes.Length; i++)
            {
                recalcNodes.Add(i);
            }
            for (int i = 0; i < recalcNodes.Count; i++)
            {
                try
                {
                    for (int m = 0; m < nodes[recalcNodes.ElementAt(i)].Items.Length; m++)
                    {
                        int itemId = nodes[recalcNodes.ElementAt(i)].Items[m].getId();
                        double value = 0;
                        for (int k = 0; k < probabilitys.Count; k++)
                        {
                            if (probabilitys.ElementAt(k).CurrentItemId == itemId)
                            {
                                value += getMultiplyValue(k);
                            }
                        }
                        nodes[recalcNodes.ElementAt(i)].Items[m].Value = value;
                    }
                }
                catch(ParentNodeMustBeCalcFirst ex)
                {
                    recalcNodes.Add(recalcNodes.ElementAt(i));
                    for (int m = 0; m < nodes[recalcNodes.ElementAt(i)].Items.Length; m++)
                    {
                        nodes[recalcNodes.ElementAt(i)].Items[m].Value = -1;
                    }
                    continue;
                }
            }
        }

        private void load()
        {
            int[] nodeIds = NodeIdsStore.getNodeIds();

            nodes = new Node[nodeIds.Length];
            probabilitys = new List<Probability>();
            for (int i=0; i<nodeIds.Length; i++)
            {
                nodes[i] = new Node(nodeIds[i]);

                int[] nodeProbabilitysId = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getNodeProbabilitys(nodeIds[i])));
                
                for (int m=0; m<nodeProbabilitysId.Length; m++)
                {
                    probabilitys.Add(new Probability(nodeProbabilitysId[m]));
                }
            }
        }

        private double getMultiplyValue(int probabilityIndex)
        {
            Probability current = probabilitys.ElementAt(probabilityIndex);
            double result = current.Value;
            for (int i = 0; i < current.Items.Length; i++)
            {
                for (int k = 0; k < nodes.Length; k++)
                {
                    if(nodes[k].getItemValue(current.Items[i])!=-1)
                    {
                        result = result * nodes[k].getItemValue(current.Items[i]);
                        break;
                    }
                }
            }

            return result;
        }

        private void otl(string message)
        {
            TextFilesDataSaver ds = new TextFilesDataSaver();
            List<string> buf = new List<string>();
            buf.Add(message);
            TextFilesConfigFieldsOnSave conf = new TextFilesConfigFieldsOnSave(
                buf, Directory.GetCurrentDirectory() + "\\otl.txt", 0);
            ds.setConfig(conf);
            ds.execute();
        }
    }
}
