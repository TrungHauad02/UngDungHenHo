using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UngDungHenHo.DB_layer;
using UngDungHenHo.models;

namespace UngDungHenHo.BS_layer
{
    public class BLSignIn
    {
        DBMain dbMain;

        public BLSignIn() { dbMain = new DBMain(); }

        public TaiKhoan TrySignIn(NguoiDung nguoiDung)
        {
            TaiKhoan acc = new TaiKhoan();
            string error = String.Empty;
            string procName = "dbo.TrySignIn";
            SqlConnection conn = dbMain.OpenConnect();
            dbMain.Comm = new SqlCommand(procName, conn);
            dbMain.Comm.CommandType = CommandType.StoredProcedure;
            dbMain.Comm.Parameters.Add(new SqlParameter("@HoTen", nguoiDung.Name));
            dbMain.Comm.Parameters.Add(new SqlParameter("@GioiTinh", nguoiDung.Sex));
            dbMain.Comm.Parameters.Add(new SqlParameter("@NgaySinh", nguoiDung.Date));
            dbMain.Comm.Parameters.Add(new SqlParameter("@SDT", nguoiDung.Phone));
            dbMain.Comm.Parameters.Add(new SqlParameter("@Email", nguoiDung.Email));
            dbMain.Comm.Parameters.Add(new SqlParameter("@TaiKhoan", nguoiDung.Username));
            dbMain.Comm.Parameters.Add(new SqlParameter("@MatKhau", nguoiDung.Password));
            dbMain.Comm.Parameters.Add(new SqlParameter("@PhanQuyen", nguoiDung.Role));
            SqlParameter returnParameter = dbMain.Comm.Parameters.Add("@ID_DangNhap", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                dbMain.Comm.ExecuteNonQuery();
            }catch (Exception ex)
            {
                error = ex.Message;
            }
            if(error != "")
            {               
                return null;
            }
            nguoiDung.Id = (int)returnParameter.Value;
            acc.Username = nguoiDung.Username;
            acc.Password = nguoiDung.Password;
            acc.Id = nguoiDung.Id;
            return acc;
        }
    }
}
