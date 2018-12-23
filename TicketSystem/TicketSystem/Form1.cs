using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketSystem.CommonComponents.DataConverters.Realization.DS;
using TicketSystem.CommonComponents.InitialyzerComponent;
using TicketSystem.CommonComponents.WorkWithDataBase.SqlLite;
using TicketSystem.CommonComponents.WorkWithFiles.Load;
using TicketSystem.CommonComponents.WorkWithFiles.Save;
using TicketSystem.TSystem;
using TicketSystem.TSystem.Objects;
using TicketSystem.TSystem.Objects.Types.Connector;

namespace TicketSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigReader.getInstance().read();
            addRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exampleUpdateNodes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        //
        //Functions
        //

        private void addRows()
        {
            dataGridView1.Rows.Add(3);
            dataGridView1.Rows[0].Cells[0].Value = "Маленькая";
            dataGridView1.Rows[1].Cells[0].Value = "Средняя";
            dataGridView1.Rows[2].Cells[0].Value = "Большая";
            dataGridView1.Rows[0].Cells[1].Value = "0.5";
            dataGridView1.Rows[1].Cells[1].Value = "0.3";
            dataGridView1.Rows[2].Cells[1].Value = "0.2";
            dataGridView1.Rows[0].Cells[2].Value = "0.4";
            dataGridView1.Rows[1].Cells[2].Value = "0.4";
            dataGridView1.Rows[2].Cells[2].Value = "0.2";
            dataGridView1.Rows[0].Cells[3].Value = "0.2";
            dataGridView1.Rows[1].Cells[3].Value = "0.3";
            dataGridView1.Rows[2].Cells[3].Value = "0.5";

            dataGridView2.Rows.Add(3);
            dataGridView2.Rows[0].Cells[0].Value = "Маленькая";
            dataGridView2.Rows[1].Cells[0].Value = "Средняя";
            dataGridView2.Rows[2].Cells[0].Value = "Большая";
            dataGridView2.Rows[0].Cells[1].Value = "0.3";
            dataGridView2.Rows[1].Cells[1].Value = "0.4";
            dataGridView2.Rows[2].Cells[1].Value = "0.3";

            dataGridView3.Rows.Add(3);
            dataGridView3.Rows[0].Cells[0].Value = "Маленькая";
            dataGridView3.Rows[1].Cells[0].Value = "Средняя";
            dataGridView3.Rows[2].Cells[0].Value = "Большая";
            dataGridView3.Rows[0].Cells[1].Value = "0.4";
            dataGridView3.Rows[1].Cells[1].Value = "0.4";
            dataGridView3.Rows[2].Cells[1].Value = "0.2";

            dataGridView4.Rows.Add(3);
            dataGridView4.Rows[0].Cells[0].Value = "Низкая";
            dataGridView4.Rows[1].Cells[0].Value = "Средняя";
            dataGridView4.Rows[2].Cells[0].Value = "Высокая";
            dataGridView4.Rows[0].Cells[1].Value = "0.2";
            dataGridView4.Rows[1].Cells[1].Value = "0.5";
            dataGridView4.Rows[2].Cells[1].Value = "0.3";

            dataGridView5.Rows.Add(3);
            dataGridView5.Rows[0].Cells[0].Value = "Свободен";
            dataGridView5.Rows[1].Cells[0].Value = "Достаточно";
            dataGridView5.Rows[2].Cells[0].Value = "Занят";
            dataGridView5.Rows[0].Cells[1].Value = "0.3";
            dataGridView5.Rows[1].Cells[1].Value = "0.6";
            dataGridView5.Rows[2].Cells[1].Value = "0.1";

            dataGridView6.Rows.Add(3);
            dataGridView6.Rows[0].Cells[0].Value = "Junior";
            dataGridView6.Rows[1].Cells[0].Value = "Middle";
            dataGridView6.Rows[2].Cells[0].Value = "Senior";
            dataGridView6.Rows[0].Cells[1].Value = "0.5";
            dataGridView6.Rows[1].Cells[1].Value = "0.3";
            dataGridView6.Rows[2].Cells[1].Value = "0.2";

            dataGridView7.Rows.Add(4);
            dataGridView7.Rows[0].Cells[0].Value = "Степень загрузки задачами";
            dataGridView7.Rows[1].Cells[0].Value = "Низкая";
            dataGridView7.Rows[2].Cells[0].Value = "Средняя";
            dataGridView7.Rows[3].Cells[0].Value = "Высокая";
            dataGridView7.Rows[0].Cells[1].Value = "Низкая";
            dataGridView7.Rows[0].Cells[2].Value = "Средняя";
            dataGridView7.Rows[0].Cells[3].Value = "Высокая";
            dataGridView7.Rows[0].Cells[4].Value = "Низкая";
            dataGridView7.Rows[0].Cells[5].Value = "Средняя";
            dataGridView7.Rows[0].Cells[6].Value = "Высокая";
            dataGridView7.Rows[0].Cells[7].Value = "Низкая";
            dataGridView7.Rows[0].Cells[8].Value = "Средняя";
            dataGridView7.Rows[0].Cells[9].Value = "Высокая";
            dataGridView7.Rows[1].Cells[1].Value = "0.8";
            dataGridView7.Rows[2].Cells[1].Value = "0.1";
            dataGridView7.Rows[3].Cells[1].Value = "0.1";
            dataGridView7.Rows[1].Cells[2].Value = "0.7";
            dataGridView7.Rows[2].Cells[2].Value = "0.2";
            dataGridView7.Rows[3].Cells[2].Value = "0.1";
            dataGridView7.Rows[1].Cells[3].Value = "0.6";
            dataGridView7.Rows[2].Cells[3].Value = "0.2";
            dataGridView7.Rows[3].Cells[3].Value = "0.2";
            dataGridView7.Rows[1].Cells[4].Value = "0.7";
            dataGridView7.Rows[2].Cells[4].Value = "0.2";
            dataGridView7.Rows[3].Cells[4].Value = "0.1";
            dataGridView7.Rows[1].Cells[5].Value = "0.3";
            dataGridView7.Rows[2].Cells[5].Value = "0.4";
            dataGridView7.Rows[3].Cells[5].Value = "0.3";
            dataGridView7.Rows[1].Cells[6].Value = "0.3";
            dataGridView7.Rows[2].Cells[6].Value = "0.3";
            dataGridView7.Rows[3].Cells[6].Value = "0.4";
            dataGridView7.Rows[1].Cells[7].Value = "0.6";
            dataGridView7.Rows[2].Cells[7].Value = "0.2";
            dataGridView7.Rows[3].Cells[7].Value = "0.2";
            dataGridView7.Rows[1].Cells[8].Value = "0.3";
            dataGridView7.Rows[2].Cells[8].Value = "0.3";
            dataGridView7.Rows[3].Cells[8].Value = "0.4";
            dataGridView7.Rows[1].Cells[9].Value = "0.1";
            dataGridView7.Rows[2].Cells[9].Value = "0.1";
            dataGridView7.Rows[3].Cells[9].Value = "0.8";

            dataGridView8.Rows.Add(4);
            dataGridView8.Rows[0].Cells[0].Value = "Заработная плата";
            dataGridView8.Rows[1].Cells[0].Value = "Низкая";
            dataGridView8.Rows[2].Cells[0].Value = "Средняя";
            dataGridView8.Rows[3].Cells[0].Value = "Высокая";
            dataGridView8.Rows[0].Cells[1].Value = "Низкая";
            dataGridView8.Rows[0].Cells[2].Value = "Средняя";
            dataGridView8.Rows[0].Cells[3].Value = "Высокая";
            dataGridView8.Rows[0].Cells[4].Value = "Низкая";
            dataGridView8.Rows[0].Cells[5].Value = "Средняя";
            dataGridView8.Rows[0].Cells[6].Value = "Высокая";
            dataGridView8.Rows[0].Cells[7].Value = "Низкая";
            dataGridView8.Rows[0].Cells[8].Value = "Средняя";
            dataGridView8.Rows[0].Cells[9].Value = "Высокая";
            dataGridView8.Rows[1].Cells[1].Value = "0.5";
            dataGridView8.Rows[2].Cells[1].Value = "0.3";
            dataGridView8.Rows[3].Cells[1].Value = "0.2";
            dataGridView8.Rows[1].Cells[2].Value = "0.4";
            dataGridView8.Rows[2].Cells[2].Value = "0.4";
            dataGridView8.Rows[3].Cells[2].Value = "0.2";
            dataGridView8.Rows[1].Cells[3].Value = "0.3";
            dataGridView8.Rows[2].Cells[3].Value = "0.4";
            dataGridView8.Rows[3].Cells[3].Value = "0.3";
            dataGridView8.Rows[1].Cells[4].Value = "0.6";
            dataGridView8.Rows[2].Cells[4].Value = "0.3";
            dataGridView8.Rows[3].Cells[4].Value = "0.1";
            dataGridView8.Rows[1].Cells[5].Value = "0.5";
            dataGridView8.Rows[2].Cells[5].Value = "0.3";
            dataGridView8.Rows[3].Cells[5].Value = "0.2";
            dataGridView8.Rows[1].Cells[6].Value = "0.4";
            dataGridView8.Rows[2].Cells[6].Value = "0.4";
            dataGridView8.Rows[3].Cells[6].Value = "0.2";
            dataGridView8.Rows[1].Cells[7].Value = "0.7";
            dataGridView8.Rows[2].Cells[7].Value = "0.2";
            dataGridView8.Rows[3].Cells[7].Value = "0.1";
            dataGridView8.Rows[1].Cells[8].Value = "0.6";
            dataGridView8.Rows[2].Cells[8].Value = "0.3";
            dataGridView8.Rows[3].Cells[8].Value = "0.1";
            dataGridView8.Rows[1].Cells[9].Value = "0.5";
            dataGridView8.Rows[2].Cells[9].Value = "0.3";
            dataGridView8.Rows[3].Cells[9].Value = "0.2";

            dataGridView9.Rows.Add(4);
            dataGridView9.Rows[0].Cells[0].Value = "Мотивация выполнить задачу";
            dataGridView9.Rows[1].Cells[0].Value = "Низкая";
            dataGridView9.Rows[2].Cells[0].Value = "Средняя";
            dataGridView9.Rows[3].Cells[0].Value = "Высокая";
            dataGridView9.Rows[0].Cells[1].Value = "Низкая";
            dataGridView9.Rows[0].Cells[2].Value = "Средняя";
            dataGridView9.Rows[0].Cells[3].Value = "Высокая";
            dataGridView9.Rows[0].Cells[4].Value = "Низкая";
            dataGridView9.Rows[0].Cells[5].Value = "Средняя";
            dataGridView9.Rows[0].Cells[6].Value = "Высокая";
            dataGridView9.Rows[0].Cells[7].Value = "Низкая";
            dataGridView9.Rows[0].Cells[8].Value = "Средняя";
            dataGridView9.Rows[0].Cells[9].Value = "Высокая";
            dataGridView9.Rows[1].Cells[1].Value = "0.7";
            dataGridView9.Rows[2].Cells[1].Value = "0.2";
            dataGridView9.Rows[3].Cells[1].Value = "0.1";
            dataGridView9.Rows[1].Cells[2].Value = "0.65";
            dataGridView9.Rows[2].Cells[2].Value = "0.25";
            dataGridView9.Rows[3].Cells[2].Value = "0.1";
            dataGridView9.Rows[1].Cells[3].Value = "0.6";
            dataGridView9.Rows[2].Cells[3].Value = "0.25";
            dataGridView9.Rows[3].Cells[3].Value = "0.15";
            dataGridView9.Rows[1].Cells[4].Value = "0.6";
            dataGridView9.Rows[2].Cells[4].Value = "0.2";
            dataGridView9.Rows[3].Cells[4].Value = "0.2";
            dataGridView9.Rows[1].Cells[5].Value = "0.55";
            dataGridView9.Rows[2].Cells[5].Value = "0.25";
            dataGridView9.Rows[3].Cells[5].Value = "0.2";
            dataGridView9.Rows[1].Cells[6].Value = "0.5";
            dataGridView9.Rows[2].Cells[6].Value = "0.25";
            dataGridView9.Rows[3].Cells[6].Value = "0.25";
            dataGridView9.Rows[1].Cells[7].Value = "0.5";
            dataGridView9.Rows[2].Cells[7].Value = "0.3";
            dataGridView9.Rows[3].Cells[7].Value = "0.2";
            dataGridView9.Rows[1].Cells[8].Value = "0.4";
            dataGridView9.Rows[2].Cells[8].Value = "0.3";
            dataGridView9.Rows[3].Cells[8].Value = "0.3";
            dataGridView9.Rows[1].Cells[9].Value = "0.3";
            dataGridView9.Rows[2].Cells[9].Value = "0.3";
            dataGridView9.Rows[3].Cells[9].Value = "0.4";

            dataGridView10.Rows.Add(6);
            dataGridView10.Rows[0].Cells[0].Value = "Уровень професиилнальной подготовки";
            dataGridView10.Rows[1].Cells[0].Value = "Наличие свободного времени";
            dataGridView10.Rows[2].Cells[0].Value = "Степень усталости";
            dataGridView10.Rows[3].Cells[0].Value = "Недостаток";
            dataGridView10.Rows[4].Cells[0].Value = "Удовлетворительно";
            dataGridView10.Rows[5].Cells[0].Value = "Достаточно";
        }
        
        private void exampleUpdateNodes()
        {
            Model model = new Model();
            testcalc(model);
            int zp = 0;
            int tasks = 0;
            for (int i = 0; i < model.getNodes().Length; i++)
            {
                if (model.getNodes()[i].getName().Equals("Salary"))
                {
                    zp = i;
                }
                if (model.getNodes()[i].getName().Equals("Degree of workload tasks"))
                {
                    tasks = i;
                }
            }
            model.getNodes()[zp].Items[0].Value = 0;
            model.getNodes()[zp].Items[1].Value = 1;
            model.getNodes()[zp].Items[2].Value = 0;
            model.getNodes()[tasks].Items[0].Value = 0;
            model.getNodes()[tasks].Items[1].Value = 1;
            model.getNodes()[tasks].Items[2].Value = 0;

            for (int i = 0; i < model.getConnects().Length; i++)
            {
                if (model.getConnects()[i].getFrom().getId() == model.getNodes()[zp].getId())
                {
                    model.getConnects()[i].getTo().Status = ConnectorStatusFabric.haveUpdate;
                }
                if (model.getConnects()[i].getTo().getId() == model.getNodes()[zp].getId())
                {
                    model.getConnects()[i].getFrom().Status = ConnectorStatusFabric.haveUpdate;
                }
                if (model.getConnects()[i].getFrom().getId() == model.getNodes()[tasks].getId())
                {
                    model.getConnects()[i].getTo().Status = ConnectorStatusFabric.haveUpdate;
                }
                if (model.getConnects()[i].getTo().getId() == model.getNodes()[tasks].getId())
                {
                    model.getConnects()[i].getFrom().Status = ConnectorStatusFabric.haveUpdate;
                }
            }
            model.updateNodes();
        }
        
        private void a()
        {
            TextFilesDataLoader loader = new TextFilesDataLoader();
            TextFilesConfigFieldsOnLoad conf = new TextFilesConfigFieldsOnLoad(
                Directory.GetCurrentDirectory() + "\\1.txt");
            loader.setConfig(conf);
            loader.execute();

            List<string> buf = loader.getResult();
            int start = 71;
            for(int i=0; i<buf.Count; i++)
            {
                if(buf.ElementAt(i).Contains("Insert into Objects values(null, 'Probability');"))
                {
                    start++;
                }
                int value = start - 1;
                string line = buf.ElementAt(i).Replace(value.ToString(), start.ToString());
                buf.RemoveAt(i);
                buf.Insert(i, line);
            }

            TextFilesDataSaver ds = new TextFilesDataSaver();
            TextFilesConfigFieldsOnSave conf2 = new TextFilesConfigFieldsOnSave(
                buf, Directory.GetCurrentDirectory() + "\\2.txt", 1);
            ds.setConfig(conf2);
            ds.execute();
        }
        
        private void testcalc(Model model)
        {
            model.calcNodesItemsValues();
            TextFilesDataSaver ds = new TextFilesDataSaver();
            List<string> data = new List<string>();
            for (int i = 0; i < model.getNodes().Length; i++)
            {
                Node current = model.getNodes()[i];
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

        private void createquerys()
        {
            TextFilesDataSaver ds = new TextFilesDataSaver();
            List<string> data = new List<string>();
            int obj = 149;
            int firstLvl1 = 10;
            for (int Lvl1 = 0; Lvl1 < 3; Lvl1++)
            {
                int firstLvl2 = 22;
                for (int Lvl2 = 0; Lvl2 < 3; Lvl2++)
                {
                    int firstLvl3 = 6;
                    for (int Lvl3 = 0; Lvl3 < 3; Lvl3++)
                    {
                        int firstLvl4 = 18;
                        for (int Lvl4 = 0; Lvl4 < 3; Lvl4++)
                        {
                            int firstCurrent = 34;
                            for (int currentLvl = 0; currentLvl < 3; currentLvl++)
                            {
                                data.Add("Insert into Objects values(null, 'Probability');/*" + obj + "*/");
                                data.Add("Insert into Objects_references values(" + obj + ", " + firstCurrent + ", 4);");
                                data.Add("Insert into Objects_references values(" + obj + ", " + firstLvl1 + ", 5);");
                                data.Add("Insert into Objects_references values(" + obj + ", " + firstLvl2 + ", 5);");
                                data.Add("Insert into Objects_references values(" + obj + ", " + firstLvl3 + ", 5);");
                                data.Add("Insert into Objects_references values(" + obj + ", " + firstLvl4 + ", 5);");
                                data.Add("Insert into Parameters values(" + obj + ", 6, '0.33');");
                                firstCurrent++;
                                obj++;
                            }
                            data.Add("");
                            firstLvl4++;
                        }
                        data.Add("");
                        firstLvl3++;
                    }
                    firstLvl2++;
                }
                firstLvl1++;
            }
            //data.Add("Hello world");
            TextFilesConfigFieldsOnSave conf = new TextFilesConfigFieldsOnSave(
                data, Directory.GetCurrentDirectory() + "\\test.txt", 1);
            ds.setConfig(conf);
            ds.execute();
        }

        private void checkDB()
        {
            string[] buf =
                DataSetConverter.fromDsToBuf.toStringBuf.
                convert(SqlLiteSimpleExecute.execute("Select name from objects"));
        }
    }
}
