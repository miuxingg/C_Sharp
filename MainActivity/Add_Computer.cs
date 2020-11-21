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
    public partial class Add_Computer : Form
    {
        //SqlConnection connection;
        //SqlCommand command = new SqlCommand();
        //SqlDataAdapter adapter;
        //DataTable table;
        //string str = "Data Source=ADMIN;Initial Catalog=INTERNET;Integrated Security=True";

        //DataProcess coon;
        DataTable table;

        private void loaddata(string sqltable)
        {
            //table = new DataTable();
            //adapter = new SqlDataAdapter("select * from " + sqltable, str);
            //table.Clear();
            //adapter.Fill(table);
            table = DataProcess.Instance.selectTable("select * from " +sqltable);
            
        }

        public Add_Computer()
        {
            InitializeComponent();
        }


        private void Add_Computer_Load(object sender, EventArgs e)
        {
            DataProcess.Instance.Connection();

            loaddata("tRoom");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDRoom.Items.Add(dr[0].ToString());
            }

            loaddata("tHardDrive");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDHardDisk.Items.Add(dr[0].ToString());
            }

            loaddata("tCapacity");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDCapacity.Items.Add(dr[0].ToString());
            }

            loaddata("tChip");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDChip.Items.Add(dr[0].ToString());
            }

            loaddata("tRam");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDRam.Items.Add(dr[0].ToString());
            }

            loaddata("tSpeed");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDSpeed.Items.Add(dr[0].ToString());
            }

            loaddata("tScreen");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDScreen.Items.Add(dr[0].ToString());
            }

            loaddata("tSizeScreen");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDSizeScreen.Items.Add(dr[0].ToString());
            }

            loaddata("tMouse");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDMouse.Items.Add(dr[0].ToString());
            }

            loaddata("tKeybroad");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDKeybroad.Items.Add(dr[0].ToString());
            }

            loaddata("tRom");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDRom.Items.Add(dr[0].ToString());
            }

            loaddata("tSpeaker");
            foreach (DataRow dr in table.Rows)
            {
                cbbIDSpeaker.Items.Add(dr[0].ToString());
            }
        }

        private void cbbIdRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool checkid()
        {
            loaddata("tComputer");
            foreach(DataRow row in table.Rows)
            {
                if (row[0].ToString().Equals(txtId.Text)) return false;
            }
            return true;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                notice("ID máy tính");
            }
            else if (txtName.Text.Equals(""))
            {
                notice("Tên máy tính");
            }
            else if (cbbIDHardDisk.Text.Equals(""))
            {
                notice("Mã phòng");
            }
            else if (cbbIDCapacity.Text.Equals(""))
            {
                notice("Dung lượng");
            }
            else if (cbbIDChip.Text.Equals(""))
            {
                notice("Chíp");
            }
            else if (cbbIDRam.Text.Equals(""))
            {
                notice("RAM");
            }
            else if (cbbIDSpeed.Text.Equals(""))
            {
                notice("Tốc độ");
            }
            else if (cbbIDScreen.Text.Equals(""))
            {
                notice("Màn hình");
            }
            else if (cbbIDSizeScreen.Text.Equals(""))
            {
                notice("Cỡ màn hình");
            }
            else if (cbbIDMouse.Text.Equals(""))
            {
                notice("Chuột");
            }
            else if (cbbIDKeybroad.Text.Equals(""))
            {
                notice("Bàn phím");
            }
            else if (cbbIDRom.Text.Equals(""))
            {
                notice("ROM");
            }
            else if (cbbIDSpeaker.Text.Equals(""))
            {
                notice("Loa");
            }
            else
            {
                if (checkid())
                {
                    Insert_Accessories insert = new Insert_Accessories();
                    insert.Insert_Computer(txtId.Text, txtName.Text, cbbIDRoom.Text, cbbIDHardDisk.Text, cbbIDCapacity.Text, cbbIDChip.Text, cbbIDRam.Text, cbbIDSpeed.Text, cbbIDScreen.Text, cbbIDSizeScreen.Text, cbbIDMouse.Text, cbbIDKeybroad.Text, cbbIDRom.Text, cbbIDSpeaker.Text, 0, txtNote.Text);
                    MessageBox.Show("Insert Success!!");
                }
                else
                {
                    MessageBox.Show("ID máy tính đã tồn tại", "Thông báo");
                    txtId.Focus();
                }
            }
        }

        private void notice(string str)
        {
            MessageBox.Show(str+" không được để trống", "Thông báo!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }
    }
}
