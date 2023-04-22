using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_sqlite.Model
{
    public class Profile
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Emailkhoiphuc { get; set; }
        public string UserAgent { get; set; }
        public string Proxy { get; set; }
        public int Status { get; set; }
        public string Sodienthoai { get; set; }
    }
}
