using System;
using System.Collections.Generic;
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
            string query = $"EXEC dbo.SignIn @HoTen = {nguoiDung.Name}, @GioiTinh = {nguoiDung.Sex}, @NgaySinh = {nguoiDung.Date}," +
                $"@SDT = {nguoiDung.Phone}, @Email = {nguoiDung.Email}, @TaiKhoan = {nguoiDung.Username}, @MatKhau = {nguoiDung.Password}," +
                $"@PhanQuyen = {nguoiDung.Role};";
            string error = String.Empty;
            dbMain.MyExecuteNonQuery(query, System.Data.CommandType.Text, ref error); ;
            if(error != "")
            {
                MessageBox.Show(error, "ERROR",MessageBoxButton.OK,MessageBoxImage.Error);
                return null;
            }
            MessageBox.Show("SignIn succeed. Welcome", "Congratulation");
            acc.Username = nguoiDung.Username;
            acc.Id = nguoiDung.Role;
            return acc;
        }
    }
}
