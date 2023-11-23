using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;
using UngDungHenHo.models;

namespace UngDungHenHo.BS_layer
{
    public class BLQLSoThich
    {
        DBMain dbMain = new DBMain();
        public BLQLSoThich()
        {

        }
        public DataTable LaySoThich()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM v_SoThich", dbMain.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public int ThemSoThich(string tenSoThich)
        {
            int idSoThich = 0;
            SqlCommand cmd = new SqlCommand("proc_ThemSoThich", dbMain.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenSoThich", tenSoThich);
            idSoThich = Convert.ToInt32(cmd.ExecuteScalar());
            return idSoThich;
        }

        public DataTable CapNhatSoThich(int idSoThich, string tenSoThich)
        {
            SqlCommand cmd = new SqlCommand("proc_CapNhatSoThich", dbMain.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SoThich", idSoThich);
            cmd.Parameters.AddWithValue("@TenSoThich", tenSoThich);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
