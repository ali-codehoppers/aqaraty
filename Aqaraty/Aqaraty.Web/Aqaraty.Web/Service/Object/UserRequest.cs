using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aqaraty.Web.Service.Object
{
    public class UserRequest
    {
        public string id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool remember { get; set; }
        public string challenge { get; set; }
        public string response { get; set; }
        public string office { get; set; }
    }
}