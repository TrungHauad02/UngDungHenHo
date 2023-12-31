﻿using System;
using System.Data;
using System.Data.SqlClient;
using UngDungHenHo.DB_layer;

namespace UngDungHenHo.BS_layer
{
    public class BLReport
    {
        DBMain dbMain = new DBMain();
        public BLReport()
        {

        }

        public DataTable LayNoiDungBaoCao()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM v_BaoCao", dbMain.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable LayDSChan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DSTaiKhoanBiChan()", dbMain.OpenConnect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable CapNhatNoiDungPhanHoi(int idBaoCao, int idQuanTri, DateTime ngayPhanHoi, string noiDung)
        { 
            SqlCommand cmd = new SqlCommand("CapNhatBaoCao", dbMain.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_BaoCao", idBaoCao);
            cmd.Parameters.AddWithValue("@ID_QuanTri", idQuanTri);
            cmd.Parameters.AddWithValue("@ThoiGianPhanHoi", ngayPhanHoi);
            cmd.Parameters.AddWithValue("@NoiDungPhanHoi", noiDung);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
            
        }

        public void ChanNguoiDung()
        {
            SqlCommand cmd = new SqlCommand("ChanNguoiDung", dbMain.OpenConnect());
            cmd.ExecuteNonQuery();
        }

        public bool LayTrangThaiND(int id_nguoiDung)
        {
            string query = $"Select TrangThai from dbo.NGUOIDUNG where ID_NguoiDung = {id_nguoiDung}";
            string error = String.Empty;
            DataTable dt = dbMain.ExecuteQueryDataSet(query, CommandType.Text, ref error).Tables[0];
            return dt.Rows[0]["TrangThai"].ToString() == "1";
        }

        public string NDBaoCao(int id_nguoiDung)
        {
            string noiDungBaoCao = string.Empty;
            SqlCommand command = new SqlCommand("SELECT NoiDungBaoCao FROM BAOCAO WHERE ID_NguoiDungBiBaoCao = @ID_NguoiDungBiBaoCao", dbMain.OpenConnect());
            command.Parameters.AddWithValue("@ID_NguoiDungBiBaoCao", id_nguoiDung);
            // Thực hiện truy vấn
            SqlDataReader reader = command.ExecuteReader();

            // Kiểm tra xem có dữ liệu hay không
            if (reader.HasRows)
            {
                // Đọc dữ liệu từ SqlDataReader
                while (reader.Read())
                {
                    // Lấy giá trị từ cột "NoiDungBaoCao"
                    noiDungBaoCao = reader["NoiDungBaoCao"].ToString();
                }
                reader.Close();
            }
            return noiDungBaoCao;
        }
    }
}
