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
    internal class BLHome
    {
     
        public DBMain db = new DBMain();
        public BLHome() { }
        public DataTable LayDanhSachNguoiDung()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_NguoiDung", db.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable LayDanhSachBaiVietNguoiDung(int IDNguoiDung)
        {
            SqlCommand cmd = new SqlCommand("select  * from dbo.func_LayDanhSachBaiVietNguoiDung(@IDNguoiDung)", db.OpenConnect());
            cmd.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable LayDanhSoThichNguoiDung(int IDNguoiDung)
        {
            SqlCommand cmd = new SqlCommand("select  * from dbo.func_Laydanhsachsothichcuanguoidung(@IDNguoiDung)", db.OpenConnect());
            cmd.Parameters.AddWithValue("@IDNguoiDung", IDNguoiDung);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public void ThemNguoiDungThich(int IdNguoithich, int IdNguoiDuocthich)
        {

            SqlCommand cmd = new SqlCommand("dbo.ThemThichNguoiDung", db.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdNguoithich", IdNguoithich);
            cmd.Parameters.AddWithValue("@IdNguoiDuocthich", IdNguoiDuocthich);
            cmd.ExecuteNonQuery();

        }
    }
}
