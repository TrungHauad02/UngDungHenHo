using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;

namespace UngDungHenHo.models
{
    internal class TinNhan
    {
        private int id;
        private string content;
        private DateTime date;
        private int id_gui;
        private int id_nhan;
        private Point loc;
      
        public TinNhan(int id, string content, DateTime date, int id_gui, int id_nhan, Point loc)
        {
            this.id = id;
            this.content = content;
            this.date = date;
            this.id_gui = id_gui;
            this.id_nhan = id_nhan;
            this.loc = loc;
           
        }

        public int Id { get => id; set => id = value; }
        public string Content { get => content; set => content = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Id_gui { get => id_gui; set => id_gui = value; }
        public int Id_nhan { get => id_nhan; set => id_nhan = value; }
        public Point Loc { get => loc; set => loc = value; }
    }
}
