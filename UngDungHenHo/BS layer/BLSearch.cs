using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;

namespace UngDungHenHo.BS_layer
{
    internal class BLSearch
    {
        DBMain db = new DBMain();
        public BLSearch()
        {

        }
        public DataTable TimKiemND(string TenNguoiDung, ref string err)
        {
            string query = "SELECT * FROM NGUOIDUNG WHERE HoTen LIKE '%" + TenNguoiDung + "%'";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0]; // Execute the query with 'MaDG';
        }
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Save the Bitmap to the MemoryStream in a specific format (e.g., PNG)
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                // Get the byte array from the MemoryStream
                return stream.ToArray();
            }
        }
        public DataTable GetNguoiDungInfoById(int IdDangNhap)
        {
            string query = $"SELECT * From dbo.GetNguoiDungById_DangNhap({IdDangNhap})";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
    }
}
