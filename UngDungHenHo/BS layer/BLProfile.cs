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
    }
}
