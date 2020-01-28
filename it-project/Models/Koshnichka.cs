using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace it_project.Models
{
    public class Koshnichka
    {
        public Burger burger { get; set; }
        public int Kolicina { get; set; }

        public Koshnichka()
        {
        }

        public Koshnichka(Burger burger, int Kolicina)
        {
            this.burger = burger;
            this.Kolicina = Kolicina;
        }
    }
}