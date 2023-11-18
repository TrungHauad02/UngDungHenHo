using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungHenHo.models
{
    public class TaiKhoan
    {
        private string username;
        private string password;
        private int id;
        public TaiKhoan(string username,string password) 
        {
            this.username = username;
            this.password = password;
        }
        public TaiKhoan() { }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }
    }
}
