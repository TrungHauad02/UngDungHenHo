﻿using System;
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
            DataTable dt = dbMain.ExecuteQueryDataSet(query, CommandType.Text).Tables[0];
            if(dt.Rows[0].ToString() != "-1")
            {
                tk = new TaiKhoan();
                tk.Id = dt.Rows[0].ToString();
            }
            return tk;
        }
    }
}
