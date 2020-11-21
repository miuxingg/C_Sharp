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

        public SqlConnection Conn { get => conn; set => conn = value; }

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
        public DataTable selectTable(string query)
        {
            DataTable tb = new DataTable();
            Connection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, strConnect);
            adapter.Fill(tb);
            return tb;
        }

        public int Querry(string querry, object[] paramter = null)
        {
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
