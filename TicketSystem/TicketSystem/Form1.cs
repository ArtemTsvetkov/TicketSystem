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

namespace TicketSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigReader.getInstance().read();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testcalc();
        }



        //
        //Functions
        //

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
        
        private void testcalc()
        {
            Model model = new Model();
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
