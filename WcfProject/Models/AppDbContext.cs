using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WcfTest.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Teapot> Teapots { get; set; }

        public AppDbContext(): base("Teapots")
        {
        }
    }
}