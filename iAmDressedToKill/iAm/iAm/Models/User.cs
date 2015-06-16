using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAm.Models
{
    public class User
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String UserNameHash { get; set; }
        public String PasswordHash { get; set; }
        public String DNS { get; set; }
        public String MasterKey { get; set; }
        public String UserNameSalt { get; set; }
		public String SuccessUrl { get; set; }
		public String FailureUrl { get; set; }
    }
}