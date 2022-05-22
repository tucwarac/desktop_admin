using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_admin.Models
{
    class ResponseModel : RequiredModel
    {
        public string status { set; get; }
        public string description { set; get; }
        public string responseCode { set; get; }
    }
}
