using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_admin.Models
{
    class MenuInfoModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string text { set; get; }
        public Image image { set; get; }
        public bool visible { set; get; }
    }
}
