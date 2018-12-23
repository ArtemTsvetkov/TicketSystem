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
            dataGridView10.Rows[0].Cells[0].Value = "Уровень професcиональной подготовки";
            dataGridView10.Rows[1].Cells[0].Value = "Наличие свободного времени";
            dataGridView10.Rows[2].Cells[0].Value = "Степень усталости";
            dataGridView10.Rows[3].Cells[0].Value = "Недостаток";
            dataGridView10.Rows[4].Cells[0].Value = "Удовлетворительно";
            dataGridView10.Rows[5].Cells[0].Value = "Достаточно";
            int one = 0;
            int two = 0;
            int three = 0;
            for (int i = 1; i < dataGridView10.Rows[0].Cells.Count; i++)
            {
                if (one < 9)
                {
                    dataGridView10.Rows[0].Cells[i].Value = "Junior";
                    one++;
                    continue;
                }
                if (two < 9)
                {
                    dataGridView10.Rows[0].Cells[i].Value = "Middle";
                    two++;
                    continue;
                }
                if (three < 9)
                {
                    dataGridView10.Rows[0].Cells[i].Value = "Senior";
                    three++;
                    continue;
                }
                else
                {
                    one = 0;
                    two = 0;
                    three = 0;
                    i--;
                }
            }
            one = 0;
            two = 0;
            three = 0;
            for (int i = 1; i < dataGridView10.Rows[0].Cells.Count; i++)
            {  
                if (one < 3)
                {
                    dataGridView10.Rows[1].Cells[i].Value = "Мало";
                    one++;
                    continue;
                }
                if (two < 3)
                {
                    dataGridView10.Rows[1].Cells[i].Value = "Средне";
                    two++;
                    continue;
                }
                if (three < 3)
                {
                    dataGridView10.Rows[1].Cells[i].Value = "Много";
                    three++;
                    continue;
                }
                else
                {
                    one = 0;
                    two = 0;
                    three = 0;
                    i--;
                }
            }
            one = 0;
            two = 0;
            three = 0;
            for (int i = 1; i < dataGridView10.Rows[0].Cells.Count; i++)
            {
                if (one < 1)
                {
                    dataGridView10.Rows[2].Cells[i].Value = "Низкая";
                    one++;
                    continue;
                }
                if (two < 1)
                {
                    dataGridView10.Rows[2].Cells[i].Value = "Средняя";
                    two++;
                    continue;
                }
                if (three < 1)
                {
                    dataGridView10.Rows[2].Cells[i].Value = "Высокая";
                    three++;
                    continue;
                }
                else
                {
                    one = 0;
                    two = 0;
                    three = 0;
                    i--;
                }
            }
            for (int i = 1; i < dataGridView10.Rows[0].Cells.Count; i++)
            {
                for (int k = 3; k < dataGridView10.Rows.Count; k++)
                {
                    dataGridView10.Rows[k].Cells[i].Value = "0.3333";
                }
            }
        }
        
        private void exampleUpdateNodes()
        {
            Model model = new Model();
            testcalc(model);
            int zp = 0;
            int tasks = 0;
            int students = 0;
            int prof = 0;
            int stepTasks = 0;
            int freeTime = 0;
            for (int i = 0; i < model.getNodes().Length; i++)
            {
                if (model.getNodes()[i].getId() == 37)
                {
                    zp = i;
                }
                if (model.getNodes()[i].getId() == 1)
                {
                    tasks = i;
                }
                if (model.getNodes()[i].getId() == 13)
                {
                    students = i;
                }
                if (model.getNodes()[i].getId() == 21)
                {
                    prof = i;
                }
                if (model.getNodes()[i].getId() == 9)
                {
                    stepTasks = i;
                }
                if (model.getNodes()[i].getId() == 5)
                {
                    freeTime = i;
                }
            }
            if(radioButton1.Checked)
            {
                model.getNodes()[zp].Items[0].Value = 1;
                model.getNodes()[zp].Items[1].Value = 0;
                model.getNodes()[zp].Items[2].Value = 0;
                updateConnects(zp, model);
            }
            if (radioButton2.Checked)
            {
                model.getNodes()[zp].Items[0].Value = 0;
                model.getNodes()[zp].Items[1].Value = 1;
                model.getNodes()[zp].Items[2].Value = 0;
                updateConnects(zp, model);
            }
            if (radioButton3.Checked)
            {
                model.getNodes()[zp].Items[0].Value = 0;
                model.getNodes()[zp].Items[1].Value = 0;
                model.getNodes()[zp].Items[2].Value = 1;
                updateConnects(zp, model);
            }
            if (radioButton5.Checked)
            {
                model.getNodes()[tasks].Items[0].Value = 1;
                model.getNodes()[tasks].Items[1].Value = 0;
                model.getNodes()[tasks].Items[2].Value = 0;
                updateConnects(tasks, model);
            }
            if (radioButton6.Checked)
            {
                model.getNodes()[tasks].Items[0].Value = 0;
                model.getNodes()[tasks].Items[1].Value = 1;
                model.getNodes()[tasks].Items[2].Value = 0;
                updateConnects(tasks, model);
            }
            if (radioButton7.Checked)
            {
                model.getNodes()[tasks].Items[0].Value = 0;
                model.getNodes()[tasks].Items[1].Value = 0;
                model.getNodes()[tasks].Items[2].Value = 1;
                updateConnects(tasks, model);
            }
            if (radioButton4.Checked)
            {
                model.getNodes()[students].Items[0].Value = 1;
                model.getNodes()[students].Items[1].Value = 0;
                model.getNodes()[students].Items[2].Value = 0;
                updateConnects(students, model);
            }
            if (radioButton8.Checked)
            {
                model.getNodes()[students].Items[0].Value = 0;
                model.getNodes()[students].Items[1].Value = 1;
                model.getNodes()[students].Items[2].Value = 0;
                updateConnects(students, model);
            }
            if (radioButton9.Checked)
            {
                model.getNodes()[students].Items[0].Value = 0;
                model.getNodes()[students].Items[1].Value = 0;
                model.getNodes()[students].Items[2].Value = 1;
                updateConnects(students, model);
            }
            if (radioButton10.Checked & !err())
            {
                model.getNodes()[prof].Items[0].Value = 1;
                model.getNodes()[prof].Items[1].Value = 0;
                model.getNodes()[prof].Items[2].Value = 0;
                updateConnects(prof, model);
            }
            if (radioButton11.Checked & !err())
            {
                model.getNodes()[prof].Items[0].Value = 0;
                model.getNodes()[prof].Items[1].Value = 1;
                model.getNodes()[prof].Items[2].Value = 0;
                updateConnects(prof, model);
            }
            if (radioButton12.Checked & !err())
            {
                model.getNodes()[prof].Items[0].Value = 0;
                model.getNodes()[prof].Items[1].Value = 0;
                model.getNodes()[prof].Items[2].Value = 1;
                updateConnects(prof, model);
            }
            if (radioButton13.Checked)
            {
                model.getNodes()[stepTasks].Items[0].Value = 1;
                model.getNodes()[stepTasks].Items[1].Value = 0;
                model.getNodes()[stepTasks].Items[2].Value = 0;
                updateConnects(stepTasks, model);
            }
            if (radioButton14.Checked)
            {
                model.getNodes()[stepTasks].Items[0].Value = 0;
                model.getNodes()[stepTasks].Items[1].Value = 1;
                model.getNodes()[stepTasks].Items[2].Value = 0;
                updateConnects(stepTasks, model);
            }
            if (radioButton15.Checked)
            {
                model.getNodes()[stepTasks].Items[0].Value = 0;
                model.getNodes()[stepTasks].Items[1].Value = 0;
                model.getNodes()[stepTasks].Items[2].Value = 1;
                updateConnects(stepTasks, model);
            }
            if (radioButton16.Checked)
            {
                model.getNodes()[freeTime].Items[0].Value = 1;
                model.getNodes()[freeTime].Items[1].Value = 0;
                model.getNodes()[freeTime].Items[2].Value = 0;
                updateConnects(freeTime, model);
            }
            if (radioButton17.Checked)
            {
                model.getNodes()[freeTime].Items[0].Value = 0;
                model.getNodes()[freeTime].Items[1].Value = 1;
                model.getNodes()[freeTime].Items[2].Value = 0;
                updateConnects(freeTime, model);
            }
            if (radioButton18.Checked)
            {
                model.getNodes()[freeTime].Items[0].Value = 0;
                model.getNodes()[freeTime].Items[1].Value = 0;
                model.getNodes()[freeTime].Items[2].Value = 1;
                updateConnects(freeTime, model);
            }
            model.updateNodes();
            printResults(model);
        }
        
        private void printResults(Model model)
        {
            int zp = 0;
            int tasks = 0;
            int students = 0;
            int prof = 0;
            int stepTasks = 0;
            int freeTime = 0;
            int fatigue = 0;
            int motiv = 0;
            int able = 0;
            int eff = 0;
            for (int i = 0; i < model.getNodes().Length; i++)
            {
                if (model.getNodes()[i].getId() == 37)
                {
                    zp = i;
                }
                if (model.getNodes()[i].getId() == 1)
                {
                    tasks = i;
                }
                if (model.getNodes()[i].getId() == 13)
                {
                    students = i;
                }
                if (model.getNodes()[i].getId() == 21)
                {
                    prof = i;
                }
                if (model.getNodes()[i].getId() == 9)
                {
                    stepTasks = i;
                }
                if (model.getNodes()[i].getId() == 5)
                {
                    freeTime = i;
                }
                if (model.getNodes()[i].getId() == 17)
                {
                    fatigue = i;
                }
                if (model.getNodes()[i].getId() == 29)
                {
                    motiv = i;
                }
                if (model.getNodes()[i].getId() == 33)
                {
                    able = i;
                }
                if (model.getNodes()[i].getId() == 25)
                {
                    eff = i;
                }
            }



            label7.Text = model.getNodes()[zp].Items[0].Value.ToString();
            label8.Text = model.getNodes()[zp].Items[1].Value.ToString();
            label9.Text = model.getNodes()[zp].Items[2].Value.ToString();

            label12.Text = model.getNodes()[tasks].Items[0].Value.ToString();
            label11.Text = model.getNodes()[tasks].Items[1].Value.ToString();
            label10.Text = model.getNodes()[tasks].Items[2].Value.ToString();

            label18.Text = model.getNodes()[students].Items[0].Value.ToString();
            label17.Text = model.getNodes()[students].Items[1].Value.ToString();
            label16.Text = model.getNodes()[students].Items[2].Value.ToString();

            label30.Text = model.getNodes()[stepTasks].Items[0].Value.ToString();
            label29.Text = model.getNodes()[stepTasks].Items[1].Value.ToString();
            label28.Text = model.getNodes()[stepTasks].Items[2].Value.ToString();

            label36.Text = model.getNodes()[freeTime].Items[0].Value.ToString();
            label35.Text = model.getNodes()[freeTime].Items[1].Value.ToString();
            label34.Text = model.getNodes()[freeTime].Items[2].Value.ToString();

            label42.Text = model.getNodes()[prof].Items[0].Value.ToString();
            label41.Text = model.getNodes()[prof].Items[1].Value.ToString();
            label40.Text = model.getNodes()[prof].Items[2].Value.ToString();

            label24.Text = model.getNodes()[fatigue].Items[0].Value.ToString();
            label23.Text = model.getNodes()[fatigue].Items[1].Value.ToString();
            label22.Text = model.getNodes()[fatigue].Items[2].Value.ToString();

            label24.Text = model.getNodes()[fatigue].Items[0].Value.ToString();
            label23.Text = model.getNodes()[fatigue].Items[1].Value.ToString();
            label22.Text = model.getNodes()[fatigue].Items[2].Value.ToString();

            label48.Text = model.getNodes()[motiv].Items[0].Value.ToString();
            label47.Text = model.getNodes()[motiv].Items[1].Value.ToString();
            label46.Text = model.getNodes()[motiv].Items[2].Value.ToString();

            label54.Text = model.getNodes()[able].Items[0].Value.ToString();
            label53.Text = model.getNodes()[able].Items[1].Value.ToString();
            label52.Text = model.getNodes()[able].Items[2].Value.ToString();

            label71.Text = model.getNodes()[eff].Items[0].Value.ToString();
            label70.Text = model.getNodes()[eff].Items[1].Value.ToString();
            label69.Text = model.getNodes()[eff].Items[2].Value.ToString();

            label1.Text = model.getNodes()[eff].Items[0].Value.ToString();
            label3.Text = model.getNodes()[eff].Items[1].Value.ToString();
            label2.Text = model.getNodes()[eff].Items[2].Value.ToString();
            try
            {
                int prg1 = (int)Math.Round(model.getNodes()[eff].Items[0].Value * 100);
                int prg3 = (int)Math.Round(model.getNodes()[eff].Items[1].Value * 100);
                int prg2 = (int)Math.Round(model.getNodes()[eff].Items[2].Value * 100);
                progressBar1.Value = prg1;
                progressBar3.Value = prg3;
                progressBar2.Value = prg2;
            }
            catch(Exception ex)
            {

            }
            model.load();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
        }

        private bool err()
        {
            if(radioButton1.Checked)
            {
                return true;
            }
            if (radioButton2.Checked)
            {
                return true;
            }
            if (radioButton3.Checked)
            {
                return true;
            }
            return false;
        }

        private void updateConnects(int node, Model model)
        {
            for (int i = 0; i < model.getConnects().Length; i++)
            {
                if (model.getConnects()[i].getFrom().getId() == model.getNodes()[node].getId())
                {
                    model.getConnects()[i].getTo().Status = ConnectorStatusFabric.haveUpdate;
                }
                if (model.getConnects()[i].getTo().getId() == model.getNodes()[node].getId())
                {
                    model.getConnects()[i].getFrom().Status = ConnectorStatusFabric.haveUpdate;
                }
            }
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
