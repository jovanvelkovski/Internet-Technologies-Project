using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace it_project.Models
{
    public class ThankYou
    {
        public ThankYou(int total, string email, string address)
        {
            this.total = total;
            this.email = email;
            this.address = address;
        }

        public int total { get; set; }
        public  string email { get; set; }
        public string address { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string PECHATI()
        {
            return email.ToString();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}