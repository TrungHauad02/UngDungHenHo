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
            return int.Parse(db.ExecuteQueryDataSet(query, CommandType.Text).Tables[0].Rows[0][0].ToString());
        }
        public DataTable LayNoiDungTinNhan(int id_gui, int id_nhan)
        {
            string query = $"execute prc_laynoidungtinnhan {id_gui},{id_nhan}";
            return db.ExecuteQueryDataSet(query,CommandType.Text).Tables[0];
        }
        public DataTable LoadNguoiDung()
        {
            string query = "select * from NGUOIDUNG";
            return db.ExecuteQueryDataSet(query, CommandType.Text).Tables[0];
        }
    }
}
