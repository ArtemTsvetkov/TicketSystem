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
                    calcNodeItems(recalcNodes.ElementAt(i));
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
            setRightStatusesOnAllNodesConnectors();
            calculateNewProbabilitysValues();
            OTLADKA();
        }

        public void OTLADKA()
        {
            TextFilesDataSaver ds = new TextFilesDataSaver();
            List<string> data = new List<string>();
            for (int i = 0; i < nodes.Length; i++)
            {
                Node current = nodes[i];
                data.Add(current.getName());
                for (int k = 0; k < current.Items.Length; k++)
                {
                    data.Add(current.Items[k].Value.ToString());
                }
                data.Add("--------------------------");
            }
            TextFilesConfigFieldsOnSave conf = new TextFilesConfigFieldsOnSave(
                data, Directory.GetCurrentDirectory() + "\\test.txt", 1);
            ds.setConfig(conf);
            ds.execute();
        }

        private void calcNodeItems(int nodeIndex)
        {
            if(nodeIndex==5)
            {
                int fsdfsfsf = 0;
            }
            for (int m = 0; m < nodes[nodeIndex].Items.Length; m++)
            {
                int itemId = nodes[nodeIndex].Items[m].getId();
                double value = 0;
                for (int k = 0; k < probabilitys.Count; k++)
                {
                    if (probabilitys.ElementAt(k).CurrentItemId == itemId)
                    {
                        value += getMultiplyValue(k);
                    }
                }
                nodes[nodeIndex].Items[m].Value = value;
            }
        }

        private void calculateNewProbabilitysValues()
        {
            int updateNode = searchNodeWithWhichHaveOnlyConnectorsWithStatuses();
            while (updateNode != -1)
            {
                updateNodeProbabilitys(updateNode);
                setStatusHaveUpdateToAllReferences(updateNode);
                updateNode = searchNodeWithWhichHaveOnlyConnectorsWithStatuses();
            }
        }

        private void updateNodeProbabilitys(int nodeIndex)
        {
            int nodeId = nodes[nodeIndex].getId();
            int connectIndex = -1;
            List<int> childsIds = new List<int>();
            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId)
                {
                    if (connects[i].getFrom().Status.getStatus().
                        Equals(ConnectorStatusFabric.haveUpdate.getStatus()))
                    {
                        connects[i].getFrom().Status = ConnectorStatusFabric.empty;
                        connectIndex = i;
                        childsIds.Add(connects[i].getTo().getId());
                    }
                }
                if (connects[i].getTo().getId() == nodeId)
                {
                    if (connects[i].getTo().Status.getStatus().
                        Equals(ConnectorStatusFabric.haveUpdate.getStatus()))
                    {
                        connects[i].getTo().Status = ConnectorStatusFabric.empty;
                        connectIndex = i;
                    }
                }
            }
            if(connects[connectIndex].getFrom().getId() == nodeId)
            {
                calcBayesProbability(nodeIndex, childsIds);
                return;
            }
            calcNodeItems(nodeIndex);
        }

        private void calcBayesProbability(int nodeIndex, List<int> childsIds)
        {
            int itemId = -1;
            //ДЛЯ ПРОСТОТЫ СЧИТАЮ, что по Байесу идет пересчет только нод, которые
            //являются parent только для 1 ноды, у которой есть обновление
            int childsIndex = -1;
            for (int i = 0; i < nodes.Length; i++)
            {
                if(nodes[i].getId()== childsIds.ElementAt(0))
                {
                    childsIndex = i;
                }
            }
            for (int i = 0; i < nodes[childsIndex].Items.Length; i++)
            {
                if (nodes[childsIndex].Items[i].Value == 1)
                {
                    itemId = nodes[nodeIndex].Items[i].getId();
                }
            }
            if (itemId != -1)
            {
                double sumOfMProbabality = sumOfMultiplyesOfCauseProbability(nodeIndex);
                for (int i = 0; i < nodes[nodeIndex].Items.Length; i++)
                {
                    int probabilityIndex = getProbabilitysWithUnswerIndex(
                        nodes[nodeIndex].Items[i].getId());
                    nodes[nodeIndex].Items[i].Value =
                       (nodes[nodeIndex].Items[i].Value * probabilitys[probabilityIndex].Value)/
                       sumOfMProbabality;
                }
            }
        }

        private double sumOfMultiplyesOfCauseProbability(int nodeIndex)
        {
            double unswer = 0;
            for (int i = 0; i < nodes[nodeIndex].Items.Length; i++)
            {
                int probabilityIndex = getProbabilitysWithUnswerIndex(
                        nodes[nodeIndex].Items[i].getId());
                unswer += nodes[nodeIndex].Items[i].Value * probabilitys[probabilityIndex].Value;
            }
            return unswer;
        }

        private int getProbabilitysWithUnswerIndex(int noCurrentItemId)
        {
            for (int i = 0; i < probabilitys.Count; i++)
            {
                for (int k = 0; k < probabilitys[i].Items.Length; k++)
                {
                    if (probabilitys[i].Items[k] == noCurrentItemId &
                        getItemValue(probabilitys[i].CurrentItemId)==1)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private double getItemValue(int itemId)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                for (int k = 0; k < nodes[i].Items.Length; k++)
                {
                    if(nodes[i].Items[k].getId()==itemId)
                    {
                        return nodes[i].Items[k].Value;
                    }
                }
            }

            return -1;
        }

        private double getValueOfProbablity(int probabilityIndex)
        {
            return probabilitys[probabilityIndex].Value;
        }

        private void setStatusHaveUpdateToAllReferences(int referencefromIndex)
        {
            int nodeId = nodes[referencefromIndex].getId();

            for (int i = 0; i < connects.Length; i++)
            {
                if (connects[i].getFrom().getId() == nodeId &
                    connects[i].getFrom().Status.getStatus().
                    Equals(ConnectorStatusFabric.needUpdate.getStatus()))
                {
                    connects[i].getFrom().Status = ConnectorStatusFabric.empty;
                    connects[i].getTo().Status = ConnectorStatusFabric.haveUpdate;
                }
                if (connects[i].getTo().getId() == nodeId &
                    connects[i].getTo().Status.getStatus().
                    Equals(ConnectorStatusFabric.needUpdate.getStatus()))
                {
                    connects[i].getTo().Status = ConnectorStatusFabric.empty;
                    connects[i].getFrom().Status = ConnectorStatusFabric.haveUpdate;
                }
            }
        }

        private int searchNodeWithWhichHaveOnlyConnectorsWithStatuses()
        {
            for (int k = 0; k < nodes.Length; k++)
            {
                int nodeId = nodes[k].getId();
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
                if (countOfAllState == countOfNeedUpdateState | countOfEmptyState>0)
                {
                    continue;
                }
                if (countOfAllState > countOfNeedUpdateState)
                {
                    return k;
                }
            }
            return -1;
        }

        private void setRightStatusesOnAllNodesConnectors()
        {
            setStatusToAllLists();

            bool allNodesSetRightStatus = false;
            while (!allNodesSetRightStatus)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (isNodeHaveOnlyOneEmptyStateAndRestsHaveStatusNeedUpdate(i))
                    {
                        setNeedUpdateStatusOnOnlyOneEmptyConnector(i);
                    }
                }
                fixImpactConnectHaveTwoEmptyStatusAndConnectedNodesHaveOnlyOneEmptyStatus();
                if (isAllConnectionsHaveStatusOnOneConnectors())
                {
                    allNodesSetRightStatus = true;
                }
            }
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
        
        private bool isAllConnectionsHaveStatusOnOneConnectors()
        {
            bool[] statuses = new bool[connects.Length];
            for (int i = 0; i < connects.Length; i++)
            {
                bool fromGetStatus = false;
                bool toGetStatus = false;
                if (!connects[i].getFrom().Status.getStatus().
                    Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    fromGetStatus =  true;
                }
                if (!connects[i].getTo().Status.getStatus().
                    Equals(ConnectorStatusFabric.empty.getStatus()))
                {
                    toGetStatus = true;
                }
                if((fromGetStatus & !toGetStatus) | (!fromGetStatus & toGetStatus))
                {
                    statuses[i] = true;
                }
                else
                {
                    statuses[i] = false;
                }
            }

            for (int i = 0; i < statuses.Length; i++)
            {
                if(statuses[i]==false)
                {
                    return false;
                }
            }

            return true;
        }
        
        public void load()
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
