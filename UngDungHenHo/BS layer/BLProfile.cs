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
    internal class BLProfile
    {
        DBMain db = new DBMain();
        public BLProfile() { }

        public DataTable GetNguoiDungInfoById(int nguoiDungId)
        {
            string query = $"SELECT * From dbo.GetNguoiDungInfoById({nguoiDungId})";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }

        public DataTable GetSoThichByNguoiDung(int nguoiDungId)
        {
            string query = $"SELECT * From dbo.GetSoThichByNguoiDung({nguoiDungId})";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
        public DataTable GetBaiVietByNguoiDungId(int nguoiDungId)
        {
            string query = $"SELECT * FROM dbo.GetBaiVietByNguoiDungId({nguoiDungId})";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }

        public DataTable GetInfoByNguoiDung1(int nguoiDungId)
        {
            string query = $"SELECT * FROM dbo.GetInfoByNguoiDung1({nguoiDungId})";
            string error = String.Empty;
            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
        public void UpdateInfoNguoiDung(int nguoiDungID, string hoTen, DateTime ngaySinh, byte[] anhDaiDien, string moTaCaNhan)
        {
            string procName = "dbo.UpdateNguoiDung";

            try
            {
                using (SqlConnection conn = db.OpenConnect())
                using (SqlCommand cmd = new SqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_NguoiDung", nguoiDungID);
                    cmd.Parameters.AddWithValue("@HoTen", hoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@AnhDaiDien", anhDaiDien);
                    cmd.Parameters.AddWithValue("@MoTaCaNhan", moTaCaNhan);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // Handle the exception or log the error
            }
        }
        public void AddSoThichForNguoiDung(int nguoiDungID, int idSoThich)
        {
            db = new DBMain();
            SqlCommand cmd = new SqlCommand("dbo.AddSoThichForNguoiDung", db.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_NguoiDung", nguoiDungID);
            cmd.Parameters.AddWithValue("@ID_SoThich", idSoThich);
            cmd.ExecuteNonQuery();

        }
        public void RemoveSoThichForNguoiDung(int nguoiDungID, int idSoThich)
        {
            db = new DBMain();
            SqlCommand cmd = new SqlCommand("dbo.DeleteSoThichForNguoiDung", db.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_NguoiDung", nguoiDungID);
            cmd.Parameters.AddWithValue("@ID_SoThich", idSoThich);
            cmd.ExecuteNonQuery();
        }
        public DataTable GetAllSoThich()
        {
            db = new DBMain();
            string query = "SELECT * FROM [NHANTINHENHO].[dbo].[SOTHICH]";
            string error = String.Empty;

            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
        public DataTable GetNguoiDungSoThichTable(int nguoiDungId)
        {
            string query = $"SELECT [ID_SoThich] FROM [NHANTINHENHO].[dbo].[SOTHICH_NGUOIDUNG] WHERE [ID_NguoiDung] = {nguoiDungId}";
            string error = String.Empty;

            return db.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
        }
    }
}
