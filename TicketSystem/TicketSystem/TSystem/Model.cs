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
using TicketSystem.TSystem.Objects.Types.Connector;
using TicketSystem.TSystem.Workers;

namespace TicketSystem.TSystem
{
    class Model
    {
        private Node[] nodes;
        private Connect[] connects;
        private List<Probability> probabilitys;

        public Model()
        {
            load();
        }

        public Node[] getNodes()
        {
            return nodes;
        }

        public Connect[] getConnects()
        {
            return connects;
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

        public void updateNodes()
        {
            setStatusToAllLists();

            bool allNodesSetRightStatus = false;
            while (!allNodesSetRightStatus)
            {
                for(int i=0; i<nodes.Length; i++)
                {
                    if(isNodeListNeedUpdate(i))
                    {

                    }
                }
            }
            fixImpactConnectHaveTwoEmptyStatusAndConnectedNodesHaveOnlyOneEmptyStatus();
        }

        private void fixImpactConnectHaveTwoEmptyStatusAndConnectedNodesHaveOnlyOneEmptyStatus()
        {
            for (int i = 0; i < connects.Length; i++)
            {
                if(connects[i].getFrom().Status.getStatus().
                    Equals(ConnectorStatusFabric.empty.getStatus()) &
                    connects[i].getTo().Status.getStatus().
                    Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    connects[i].getFrom().Status = ConnectorStatusFabric.needUpdate;
                }
            }
        }

        private void setStatusToAllLists()
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (isNodeIsList(i) & !isNodeListHaveUpdate(i))
                {
                    setStatusNeedUpdateToAllReferences(i);
                }
            }
        }

        private void setStatusNeedUpdateToAllReferences(int referencefromIndex)
        {
            int nodeId = nodes[referencefromIndex].getId();

            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId)
                {
                    if(!connects[i].getTo().Status.getStatus().
                        Equals(ConnectorStatusFabric.haveUpdate.getStatus()))
                    {
                        connects[i].getTo().Status = ConnectorStatusFabric.needUpdate;
                    }
                }
                if (connects[i].getTo().getId() == nodeId)
                {
                    if (!connects[i].getFrom().Status.getStatus().
                        Equals(ConnectorStatusFabric.haveUpdate.getStatus()))
                    {
                        connects[i].getFrom().Status = ConnectorStatusFabric.needUpdate;
                    }
                }
            }
        }

        private void setNeedUpdateStatusOnOnlyOneEmptyConnector(int referencefromIndex)
        {
            int nodeId = nodes[referencefromIndex].getId();
            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId &
                        connects[i].getFrom().Status.getStatus().
                        Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    if (connects[i].getTo().Status.getStatus().
                        Equals(ConnectorStatusFabric.empty.getStatus()))
                    {
                        connects[i].getTo().Status = ConnectorStatusFabric.needUpdate;
                    }
                }
                if (connects[i].getTo().getId() == nodeId &
                        connects[i].getTo().Status.getStatus().
                        Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    if (connects[i].getFrom().Status.getStatus().
                        Equals(ConnectorStatusFabric.empty.getStatus()))
                    {
                        connects[i].getFrom().Status = ConnectorStatusFabric.needUpdate;
                    }
                }
            }
        }

        private bool isNodeHaveOnlyOneEmptyStateAndRestsHaveStatusNeedUpdate(int nodeIndex)
        {
            int nodeId = nodes[nodeIndex].getId();
            int countOfEmptyState = 0;
            int countOfNeedUpdateState = 0;
            int countOfAllState = 0;
            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId)
                {
                    countOfAllState++;
                    if (connects[i].getFrom().Status.getStatus().
                        Equals(ConnectorStatusFabric.empty.getStatus()))
                    {
                        countOfEmptyState++;
                    }
                    if (connects[i].getFrom().Status.getStatus().
                        Equals(ConnectorStatusFabric.needUpdate.getStatus()))
                    {
                        countOfNeedUpdateState++;
                    }
                }
                if (connects[i].getTo().getId() == nodeId)
                {
                    countOfAllState++;
                    if (connects[i].getTo().Status.getStatus().
                        Equals(ConnectorStatusFabric.empty.getStatus()))
                    {
                        countOfEmptyState++;
                    }
                    if (connects[i].getTo().Status.getStatus().
                        Equals(ConnectorStatusFabric.needUpdate.getStatus()))
                    {
                        countOfNeedUpdateState++;
                    }
                }
            }
            if (countOfAllState == countOfNeedUpdateState + countOfEmptyState)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isNodeIsList(int nodeIndex)
        {
            int nodeId = nodes[nodeIndex].getId();
            bool nodeHaveParent = false;
            bool nodeHaveChild = false;
            for (int i=0; i<connects.Length; i++)
            {
                if(connects[i].getFrom().getId() == nodeId)
                {
                    nodeHaveChild = true;
                }
                if (connects[i].getTo().getId() == nodeId)
                {
                    nodeHaveParent = true;
                }
                if(nodeHaveChild & nodeHaveParent)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isNodeListHaveUpdate(int nodeIndex)
        {
            int nodeId = nodes[nodeIndex].getId();
            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId &
                    connects[i].getFrom().Status.getStatus().
                    Equals(ConnectorStatusFabric.haveUpdate.getStatus()))
                {
                    return true;
                }
                if (connects[i].getTo().getId() == nodeId &
                    connects[i].getTo().Status.getStatus().
                    Equals(ConnectorStatusFabric.haveUpdate.getStatus()))
                {
                    return true;
                }
            }

            return false;
        }

        private bool isNodeListNeedUpdate(int nodeIndex)
        {
            int nodeId = nodes[nodeIndex].getId();
            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId &
                    connects[i].getFrom().Status.getStatus().
                    Equals(ConnectorStatusFabric.needUpdate.getStatus()))
                {
                    return true;
                }
                if (connects[i].getTo().getId() == nodeId &
                    connects[i].getTo().Status.getStatus().
                    Equals(ConnectorStatusFabric.needUpdate.getStatus()))
                {
                    return true;
                }
            }

            return false;
        }

        private bool isNodeHaveStatusOnAllConnectors(int nodeIndex)
        {
            int nodeId = nodes[nodeIndex].getId();
            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId &
                    connects[i].getFrom().Status.getStatus().
                    Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    return false;
                }
                if (connects[i].getTo().getId() == nodeId &
                    connects[i].getTo().Status.getStatus().
                    Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    return false;
                }
            }

            return true;
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

            int[] connectIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                SqlLiteSimpleExecute.execute(QueryConfigurator.getAllConnectsIds()));

            connects = new Connect[connectIds.Length];
            for (int i = 0; i < connectIds.Length; i++)
            {
                connects[i] = new Connect(connectIds[i]);
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
