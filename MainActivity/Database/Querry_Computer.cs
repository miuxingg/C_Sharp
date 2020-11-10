using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainActivity.Database
{
    class Querry_Computer
    {
        public void showTable(DataGridView dgvShowAll)
        {
            //string status = dgvShowAll.Rows[e.RowIndex].Cells[3].Value.ToString();
            string status = dgvShowAll.CurrentRow.Cells[3].Value.ToString();
            if (status.Equals("Trống"))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn bật máy không", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string id = dgvShowAll.CurrentRow.Cells[0].Value.ToString();
                    //conn.Querry("update tComputer set TinhTrang = 1 where idComputer = '" + id + "'");
                    DataProcess.Instance.Querry("exec updateStatus @idcom , @tinhtrang ", new object[] { id, 1 });
                    DataProcess.Instance.selectTable("exec procshowAllComputer", dgvShowAll);
                    //command = connection.CreateCommand();
                    //command.CommandText = "update tComputer set TinhTrang = 1 where idComputer = '" + id + "'";
                    //command.ExecuteNonQuery();
                    //loaddata();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn tắt máy không", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string id = dgvShowAll.CurrentRow.Cells[0].Value.ToString();
                    //conn.Querry("update tComputer set TinhTrang = 0 where idComputer = '" + id + "'");
                    DataProcess.Instance.Querry("exec updateStatus @idcom , @tinhtrang ", new object[] { id, 0 });
                    DataProcess.Instance.selectTable("exec procshowAllComputer", dgvShowAll);
                    //command = connection.CreateCommand();
                    //command.CommandText = "update tComputer set TinhTrang = 0 where idComputer = '" + id + "'";
                    //command.ExecuteNonQuery();
                    //loaddata();
                }
            }
        }
    }
}
