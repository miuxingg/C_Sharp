using MainActivity.Database;
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
    public partial class Form1 : Form
    {
        //SqlConnection connection;
        //SqlCommand command = new SqlCommand();
        //SqlDataAdapter adapter;
        //DataTable table = new DataTable();
        //string str = "Data Source=ADMIN;Initial Catalog=INTERNET;Integrated Security=True";

        DataProcess conn = new DataProcess();
        Querry_Computer querry = new Querry_Computer();
        public Form1()
        {
            InitializeComponent();

        }
        //private void loaddata()
        //{
        //    adapter = new SqlDataAdapter("select * from " + room, str);
        //    table.Clear();
        //    adapter.Fill(table);
        //    dgvShowAll.DataSource = table;
        //}
        
        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Connection();
            conn.selectTable("exec procshowAllComputer", dgvShowAll);
            //connection = new SqlConnection(str);
            //connection.Open();
            //loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grvShow_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void grvShow_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            querry.showTable(dgvShowAll);
            
        }

        private void mnuAddCPT_Click(object sender, EventArgs e)
        {
            Add_Computer formAddComputer = new Add_Computer();
            formAddComputer.Show();
        }

        private void btnP1_Click_1(object sender, EventArgs e)
        {
            
            conn.selectTable("exec procshowComputerR1", dgvShowAll);
        }

        private void btnAll_Click_1(object sender, EventArgs e)
        {
            conn.selectTable("exec procshowAllComputer", dgvShowAll);
        }

        private void btnP2_Click_1(object sender, EventArgs e)
        {
            conn.selectTable("exec procshowComputerR2", dgvShowAll);
        }

        private void btnP3_Click_1(object sender, EventArgs e)
        {
            conn.selectTable("exec procshowComputerR3", dgvShowAll);
        }

        private void btnP4_Click_1(object sender, EventArgs e)
        {
            conn.selectTable("exec procshowComputerR4", dgvShowAll);
        }
    }
}
