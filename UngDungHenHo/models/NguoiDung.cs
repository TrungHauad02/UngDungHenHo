using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UngDungHenHo.models
{
    public class NguoiDung
    {
        private int id;
        private string name;
        private int sex;  // 1 -> Male; 0 -> Female
        private DateTime date;
        private string phone;
        private string email;
        private string username;
        private string password;

        public NguoiDung()
        {
        }

        public NguoiDung(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public NguoiDung(string name, int sex, DateTime date, string phone, string email, string username, string password)
        {
            this.name = name;
            this.sex = sex;
            this.date = date;
            this.phone = phone;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public string Name { get => name; set => name = value; }
        public int Sex { get => sex; set => sex = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }
    }
}
