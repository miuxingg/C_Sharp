using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainActivity
{
    public class DataProcess
    {
        private static DataProcess instance;
        string strConnect = "Data Source=ADMIN;Initial Catalog=INTERNET;Integrated Security=True";
        SqlConnection conn = null;

        public static DataProcess Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProcess();
                return DataProcess.instance;
            }
            private set
            {
                DataProcess.instance = value;
            }
        }



        public void Connection()
        {
            conn = new SqlConnection(strConnect);
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void CloseConnect()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            conn.Dispose();
        }
        public void selectTable(string query, DataGridView gridV)
        {
            DataTable tb = new DataTable();
            Connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, strConnect);
            adapter.Fill(tb);
            gridV.DataSource = tb;
            gridV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public int Querry(string querry, object[] paramter = null)
        {
            //Connection();
            //SqlCommand command = new SqlCommand();
            //command.Connection = conn;
            //command.CommandText = querry;
            //command.ExecuteNonQuery();
            //CloseConnect();
            int data = 0;
            Connection();
            SqlCommand command = new SqlCommand(querry, conn);
            if(paramter != null)
            {
                string[] list = querry.Split(' ');
                int i = 0;
                foreach (string iteam in list)
                {
                    if (iteam.Contains('@'))
                    {
                        command.Parameters.AddWithValue(iteam, paramter[i]);
                        i++;
                    }
                }
            }

            try
            {
                data = command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                CloseConnect();
            }
            return data;
        }

    }
}
