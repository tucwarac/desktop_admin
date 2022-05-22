using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_admin.Models
{
    class VersioningModel
    {
        public string version_number { set; get; }

        public string version_date { set; get; }

        public List<string> version_description { set; get; }
    }
}
