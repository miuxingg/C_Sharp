using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainActivity.Database
{
    class Querry_Computer
    {
        private static Querry_Computer instance;
        
        public Querry_Computer()
        {
           

        }
        internal static Querry_Computer Instance
        {
            get
            {
                if (instance == null)
                    instance = new Querry_Computer();
                return Querry_Computer.instance;
            }
            private set
            {
                Querry_Computer.instance = value;
            }
        }

        public int statusOnOff(string querry,DataGridView dgvShowAll)
        {
            string status = dgvShowAll.CurrentRow.Cells[3].Value.ToString();
            if (status.Equals("Trống"))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn bật máy không", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string id = dgvShowAll.CurrentRow.Cells[0].Value.ToString();
                    DataProcess.Instance.Querry("exec updateStatus @idcom , @tinhtrang ", new object[] { id, 1 });
                    updateTimeUse(id, 1);
                    //updateTimeStart(id);
                    dgvShowAll.DataSource = DataProcess.Instance.selectTable(querry);
                }
                return 0;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn tắt máy không", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {                   
                    string id = dgvShowAll.CurrentRow.Cells[0].Value.ToString();
                    Payment Fpayment = new Payment(id);
                    Fpayment.ShowDialog();
                    
                    //DataProcess.Instance.Querry("exec updateStatus @idcom , @tinhtrang ", new object[] { id, 0 });
                    //updateTimeUse(id, 0);
                    //updateTotalMoney(id, 0);
                    //dgvShowAll.DataSource = DataProcess.Instance.selectTable(querry);
                }
            }
            return 1;
        }

        public void setStatusOff(string id)
        {
            DataProcess.Instance.Querry("exec updateStatus @idcom , @tinhtrang ", new object[] { id, 0 });
            updateTimeUse(id, 0);
            updateTotalMoney(id, 0);
            
        }
        public int getStatus(string idComp)
        {
            DataProcess.Instance.Connection();
            try
            {
                SqlCommand command = DataProcess.Instance.Conn.CreateCommand();
                command.CommandText = "getStatus";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idcom", idComp);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@tinhtrang";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
                return Convert.ToInt32(parameter.Value.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        public void updateTimeUse(string id, int time)
        {
            try
            {
                DataProcess.Instance.Querry("exec updateTimeUsed @idComuter , @intTime", new object[] { id, time });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());            
            }
        }

        public void updateTotalMoney(string id, float money)
        {
            try
            {
                DataProcess.Instance.Querry("exec updateTotalMoney @idComuter , @intTime", new object[] { id, money });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int getMoneyAtRoom(string idComp)
        {
            DataProcess.Instance.Connection();
            SqlCommand command;
            SqlParameter parameter;
            try
            {
                command = DataProcess.Instance.Conn.CreateCommand();
                command.CommandText = "getMoneyRoom";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idComuter", idComp);
                parameter = new SqlParameter();
                parameter.ParameterName = "@money";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
                return Convert.ToInt32(parameter.Value.ToString());
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.ToString());
            }
            return -1;
        }

        public void updateTimeStart(string id)
        {
            try
            {
                DataProcess.Instance.Querry("exec updateTimeStart @idcomp ", new object[] { id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void insertRentComputer(string idRoom, string idComputer, string nameGuest, string rentDay, string timein, string timeOut, string idEmployee, string total, string ghichu )
        {
            DataProcess.Instance.Querry("exec insertRentComputer @idRoom , @idComputer , @nameGuest , @rentDay , @timeIn , @timeOut , @idEmployee , @totalMoney , @ghichu ", new object[] { idRoom, idComputer, nameGuest,rentDay,timein,timeOut,idEmployee,total,ghichu });
        }
    }
}
