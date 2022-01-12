using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project113_G3.Models
{
    public partial class Datagame1 : DbContext
    {
        public Datagame1()
            : base("name=Datagame1")
        {
        }

        public virtual DbSet<Datagame> Datagame { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datagame>()
                .Property(e => e.url)
                .IsUnicode(false);
        }
    }
}
