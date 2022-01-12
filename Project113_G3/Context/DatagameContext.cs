using Project113_G3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project113_G3.Context
{
    public class DatagameContext : DbContext
    {
        public DbSet<Datagame> Datagame { get; set; }

    }
}