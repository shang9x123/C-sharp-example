using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_sqlite.Model
{
    

    public class Profile 
    {
        private string _Email;
        public string Email
        {
            get => _Email;
            set
            {
            }
        }
        public string Password { get; set; }
        public string Emailkhoiphuc { get; set; }
        public string UserAgent { get; set; }
        public string Proxy { get; set; }
        public int Status { get; set; }
        public string Sodienthoai { get; set; }

    }
}
