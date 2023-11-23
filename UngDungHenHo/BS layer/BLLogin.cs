using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;
using UngDungHenHo.models;

namespace UngDungHenHo.BS_layer
{
    public class BLLogin
    {
        DBMain dbMain;
        public BLLogin() { dbMain = new DBMain(); }

        public TaiKhoan TryLogin(TaiKhoan acc)
        {
            TaiKhoan tk = null;
            string query = $"SELECT dbo.ValidateLogin('{acc.Username}', '{acc.Password}')";
            string error = String.Empty;
            DataTable dt = dbMain.ExecuteQueryDataSet(query, CommandType.Text,ref error).Tables[0];
            if(dt.Rows[0].ToString() != "-1")
            {
                tk = new TaiKhoan();
                tk.Id = Int32.Parse(dt.Rows[0][0].ToString());
                query = $"SELECT dbo.GetRoleByIDDangNhap({tk.Id})";
                dt = dbMain.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
                tk.Role = dt.Rows[0][0].ToString();
            }
            return tk;
        }
    }
}
