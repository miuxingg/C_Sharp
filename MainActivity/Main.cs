using MainActivity.Database;
using MainActivity.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainActivity
{
    public partial class Main : Form
    {
        string room = "procshowAllComputer";

        DataProcess conn = new DataProcess();
        Querry_Computer querry = new Querry_Computer();
        Dictionary<string, int> dict;
        DataTable table;        
        DataTable tableMonth;        
        DataTable tableQuy;        
        DataTable tableYear;        
        public Main()
        {
            InitializeComponent();
            customizeDesing();
            
            loaddata();
            loadDict();
            timer1.Start();

            
        }
        
        public void loaddata()
        {
            conn.Connection();
            table = DataProcess.Instance.selectTable("exec " + room);
            dgvShowAll.DataSource = table;
        }

        private void loadDict()
        {
            
            dict = new Dictionary<string, int>();
            foreach (DataRow row in table.Rows)
            {
                int s;
                //if(querry.getStatus(row[1].ToString()) == 1)
                if (row[3].ToString() != "Trống")
                {
                    s = Convert.ToInt32(row[5].ToString());
                }
                else
                {
                    s = 0;
                }
                dict.Add(row[0].ToString(),s);
            }
            updateTime();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void customizeDesing()
        {
            panelRoom.Visible = false;
            panelReport.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelRoom.Visible == true)
            {
                panelRoom.Visible = false;
            }
            if(panelReport.Visible == true)
            {
                panelReport.Visible =  false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;

            }
            else subMenu.Visible = false;
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRoom);

        }

        private void grvShow_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i= querry.statusOnOff("exec "+ room, dgvShowAll);
            if (i==1)
                loaddata();
        }

        
        private void mnuAddCPT_Click(object sender, EventArgs e)
        {
            Add_Computer formAddComputer = new Add_Computer();
            formAddComputer.Show();
        }

        private void btnP1_Click_1(object sender, EventArgs e)
        {
            show(0);
            room = "procshowAllComputer";
            dgvShowAll.DataSource = DataProcess.Instance.selectTable("exec procshowAllComputer");
            hideSubMenu();
            
        }

        private void btnAll_Click_1(object sender, EventArgs e)
        {
            show(0);
            room = "procshowComputerR4";
            dgvShowAll.DataSource = DataProcess.Instance.selectTable("exec procshowComputerR4");
            hideSubMenu();
        }

        private void btnP2_Click_1(object sender, EventArgs e)
        {
            show(0);
            room = "procshowComputerR1";
            dgvShowAll.DataSource = DataProcess.Instance.selectTable("exec procshowComputerR1");
            hideSubMenu();
        }

        private void btnP3_Click_1(object sender, EventArgs e)
        {
            show(0);
            room = "procshowComputerR3";
            dgvShowAll.DataSource = DataProcess.Instance.selectTable("exec procshowComputerR3");
            hideSubMenu();
        }

        private void btnP4_Click_1(object sender, EventArgs e)
        {
            show(0);
            room = "procshowComputerR2";
            dgvShowAll.DataSource = DataProcess.Instance.selectTable("exec procshowComputerR2");
            hideSubMenu();
        }


        private void updateTime()
        {
            for(int i = 0; i< dict.Count; i++)
            {
                
                if (dict[dict.Keys.ElementAt(i)] != 0)
                {
                    dict[dict.Keys.ElementAt(i)]++;
                    querry.updateTimeUse(dict.Keys.ElementAt(i), dict[dict.Keys.ElementAt(i)]);
                    
                    querry.updateTotalMoney(dict.Keys.ElementAt(i), dict[dict.Keys.ElementAt(i)] * querry.getMoneyAtRoom(dict.Keys.ElementAt(i)));
                    
                }
                else
                {
                    
                }
            }
            
        }
        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            loaddata();
            loadDict();
            
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReport);
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            show(1);
            foreach(DataRow row in DataProcess.Instance.selectTable("exec getYear").Rows)
            {
                cbbYear.Items.Add(row[0].ToString());
            }
            cbbYear.SelectedIndex = 0;
            
        }

        private void show(int s)
        {
            if(s == 0)
            {
                cbbYear.Visible = false;
                labelYear.Visible = false;
                btnExcel.Visible = false;
                lableMonth.Visible = false;
                labelQuarterly.Visible = false;
                dgvShowAll.Visible = true;
                dgvMonth.Visible = false;
                dgvQuy.Visible = false;
                dgvYear.Visible = false;
            }
            else
            {
                cbbYear.Visible = true;
                labelYear.Visible = true;
                btnExcel.Visible = true;
                lableMonth.Visible = true;
                labelQuarterly.Visible = true;
                dgvShowAll.Visible = false;
                dgvMonth.Visible = true;
                dgvQuy.Visible = true;
                dgvYear.Visible = true;
            }
        }

        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            show(1);
            tableMonth = new DataTable();
            tableQuy = new DataTable();
            tableYear = new DataTable();
            tableMonth = DataProcess.Instance.selectTable("exec report " + cbbYear.Text);
            dgvMonth.DataSource = tableMonth;
            tableQuy = DataProcess.Instance.selectTable("exec reportQuy " + cbbYear.Text);
            dgvQuy.DataSource = tableQuy;
            tableYear = DataProcess.Instance.selectTable("exec reportYear " + cbbYear.Text);
            dgvYear.DataSource = tableYear;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ReportMaintenance report = new ReportMaintenance();
            DialogResult result = MessageBox.Show("Chắc chắn muốn xuất", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                report.ReportMainenance1(tableMonth, tableQuy, tableYear);
                MessageBox.Show("Success","Notification");
            }
        }
    }
}
