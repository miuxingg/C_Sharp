using MainActivity.Database;
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
    public partial class Payment : Form
    {
        private string id = "";
        DataTable table;
        private string idEmployee;
        public Payment()
        {
            InitializeComponent();
        }

        public Payment(string id)
        {
            this.id = id;
            DataProcess.Instance.Connection();
            InitializeComponent();
        }

        private void loaddata(string id)
        {
            table = new DataTable();
            table = DataProcess.Instance.selectTable("exec getInfoId " + id);
           
        }
        private void Payment_Load(object sender, EventArgs e)
        {
            loaddata(id);
            foreach (DataRow dr in DataProcess.Instance.selectTable("exec getEmployeesWorking").Rows)
            {
                cbbEmployee.Items.Add(dr[1].ToString());
                idEmployee = dr[0].ToString();
            }
            foreach(DataRow row in table.Rows)
            {
                txtIDRoom.Text = row["idRoom"].ToString();
                txtNgayThue.Text = row["RentDay"].ToString().Substring(0,11);
                txtTimeIn.Text = row["batdau"].ToString();
                txtTotalMoney.Text = row["totalMoney"].ToString();
                
            }
            txtTimeOut.Text = DateTime.Now.ToString();
            txtIdComputer.Text = id;
            
            cbbEmployee.SelectedIndex = 0;
            txtNote.Text = "";
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(""))
            {
                txtName.Text = "Khách hàng";
            }
            Querry_Computer.Instance.insertRentComputer(txtIDRoom.Text, txtIdComputer.Text, txtName.Text, txtNgayThue.Text, txtTimeIn.Text, txtTimeOut.Text,idEmployee,txtTotalMoney.Text,txtNote.Text);
            Querry_Computer.Instance.setStatusOff(id);
            
            this.Close();
        }
    }
}
