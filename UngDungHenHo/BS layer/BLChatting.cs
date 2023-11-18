using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;

namespace UngDungHenHo.BS_layer
{
    internal class BLChatting
    {
        DBMain db = new DBMain();
        public BLChatting()
        {

        }
        public int LayMaTinNhanMax()
        {
            string query = "select dbo.GetMaxID_TinNhan()";
            string error = String.Empty;
            return int.Parse(db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0].Rows[0][0].ToString());
        }
        public DataTable LayNoiDungTinNhan(int id_gui, int id_nhan)
        {
            string query = $"execute prc_laynoidungtinnhan {id_gui},{id_nhan}";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query,CommandType.Text, ref error).Tables[0];
        }
        public DataTable LoadNguoiDung()
        {
            string query = "select * from NGUOIDUNG";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
        public bool ThemTinNhan(int id_gui, int id_nhan,DateTime time, string noidung, ref string err)
        {

            string query = $"INSERT INTO TINNHAN VALUES ('{noidung}', NULL, '{time.ToString("yyyy-MM-dd HH:mm:ss")}',1,{id_gui},{id_nhan})";
            return db.MyExecuteNonQuery(query, CommandType.Text, ref err);

        }
    }
}
