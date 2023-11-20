using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UngDungHenHo.DB_layer;

namespace UngDungHenHo.BS_layer
{
    internal class BLBaoCaoNguoiDung
    {

        public DBMain db = new DBMain();
        public BLBaoCaoNguoiDung() { }
        public void TaoBaoCaoNguoiDung(int ID_NguoiDungBaoCao , int ID_NguoiDungBiBaoCao,DateTime ThoiGianBaoCao,String NoiDungBaoCao)
        {

            SqlCommand cmd = new SqlCommand("dbo.Proc_TaoBaoCaoNguoiDung", db.OpenConnect());
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@ID_NguoiDungBaoCao", ID_NguoiDungBaoCao);
            cmd.Parameters.AddWithValue("@ID_NguoiDungBiBaoCao ", ID_NguoiDungBiBaoCao);
            cmd.Parameters.AddWithValue("@ThoiGianBaoCao ", ThoiGianBaoCao);
            cmd.Parameters.AddWithValue("@NoiDungBaoCao", NoiDungBaoCao);

            cmd.ExecuteNonQuery();

        }

    }
}
