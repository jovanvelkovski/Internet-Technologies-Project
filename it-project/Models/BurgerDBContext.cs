using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace it_project.Models
{
    public class BurgerDBContext : DbContext
    {
        public DbSet<Burger> Burgers { get; set; }
    }
}