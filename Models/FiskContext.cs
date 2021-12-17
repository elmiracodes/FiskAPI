using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskAPI.Models
{
    public class FiskContext : DbContext
    {
        public FiskContext()
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=fisk.db");
        }
        public DbSet<Fisk> Fisks { get; set; }


    }
}

