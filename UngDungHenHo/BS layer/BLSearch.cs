using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Jwt.AccessToken;
using UngDungHenHo.DB_layer;

namespace UngDungHenHo.BS_layer
{
    internal class BLSearch
    {
        DBMain db = new DBMain();
        public BLSearch()
        {

        }
        public DataTable TimKiemND(string TenNguoiDung, string SoThich)
        {
            SqlCommand command = new SqlCommand("TimKiemND", db.OpenConnect());
            command.CommandType = CommandType.StoredProcedure;

            // Thêm tham số vào Command
            command.Parameters.Add(new SqlParameter("@HoTen", TenNguoiDung));
            command.Parameters.Add(new SqlParameter("@TenSoThich", SoThich));
            SqlDataAdapter daND = new SqlDataAdapter(command);
            DataTable dtND = new DataTable();
            daND.Fill(dtND);
            return dtND;
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
        public DataTable GetNguoiDungInfoByIdDN(int IdDangNhap)
        {
            string query = $"SELECT * From dbo.GetNguoiDungById_DangNhap({IdDangNhap})";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
        public DataTable TimKiemSoThich()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_SOTHICH", db.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
