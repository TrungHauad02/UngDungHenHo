using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;

namespace UngDungHenHo.BS_layer
{
    public class BLReport
    {
        DBMain db = new DBMain();
        public BLReport()
        {

        }

        public DataTable LayNoiDungBaoCao()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM v_BaoCao", db.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable LayDSChan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DSTaiKhoanBiChan()", db.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable CapNhatNoiDungPhanHoi(int idBaoCao, int idQuanTri, DateTime ngayPhanHoi, string noiDung)
        { 
            SqlCommand cmd = new SqlCommand("CapNhatBaoCao", db.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_BaoCao", idBaoCao);
            cmd.Parameters.AddWithValue("@ID_QuanTri", idQuanTri);
            cmd.Parameters.AddWithValue("@ThoiGianPhanHoi", ngayPhanHoi);
            cmd.Parameters.AddWithValue("@NoiDungPhanHoi", noiDung);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
            
        }

        public void ChanNguoiDung()
        {
            SqlCommand cmd = new SqlCommand("ChanNguoiDung", db.OpenConnect());
            cmd.ExecuteNonQuery();
        }
    }
}
