using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



            return acc;
        }
    }
}
