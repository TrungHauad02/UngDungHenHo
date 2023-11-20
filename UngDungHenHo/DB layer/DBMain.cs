using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungHenHo.DB_layer
{
    internal class DBMain
    {
        string ConnStr = "Server=tcp:sqlserver-pht.database.windows.net,1433;Initial Catalog=NHANTINHENHO;Persist Security Info=False;User ID=pht;Password=PhamHuuTuan241103;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;

        public SqlCommand Comm { get => comm; set => comm = value; }

        public DBMain()
        {
            conn = new SqlConnection(ConnStr);
            Comm = conn.CreateCommand();

        }
        public SqlConnection OpenConnect()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public void CloseConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, ref string error)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            Comm.CommandText = strSQL;
            Comm.CommandType = ct;
            da = new SqlDataAdapter(Comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            Comm.CommandText = strSQL;
            Comm.CommandType = ct;
            try
            {
                Comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
    }
}
