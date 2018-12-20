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
using TicketSystem.CommonComponents.WorkWithFiles.Save;

namespace TicketSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextFilesDataSaver ds = new TextFilesDataSaver();
            List<string> data = new List<string>();
            int obj = 149;
            int firstLvl1 = 10;
            for(int Lvl1=0; Lvl1<3; Lvl1++)
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
                                data.Add("Insert into Objects values(null, 'Probability');/*"+ obj + "*/");
                                data.Add("Insert into Objects_references values(" + obj + ", "+firstCurrent+", 4);");
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
                data,Directory.GetCurrentDirectory()+"\\test.txt",1);
            ds.setConfig(conf);
            ds.execute();
        }
    }
}
