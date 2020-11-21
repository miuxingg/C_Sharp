using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainActivity
{
    public partial class Login : Form
    {
        DataTable table;
        public Login()
        {
            InitializeComponent();
            DataProcess.Instance.Connection();
            table = new DataTable();
            table = DataProcess.Instance.selectTable("select * from tAccount");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataRow row in table.Rows)
            {
                bool flat = false;
                if(txtUser.Text.Equals(row[0].ToString()) && txtPass.Text.Equals(row[1].ToString()))
                {
                    flat = true;
                    new Main().Show();
                    
                    
                }
                if(flat == false)
                {
                    MessageBox.Show("Login Eror", "Notifical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
