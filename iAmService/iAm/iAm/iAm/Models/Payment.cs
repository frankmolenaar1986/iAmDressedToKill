using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAm.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public String Debitor { get; set; }
        public String Creditor { get; set; }
        public String Description { get; set; }
        public String ReturnUrl { get; set; }
    }
}