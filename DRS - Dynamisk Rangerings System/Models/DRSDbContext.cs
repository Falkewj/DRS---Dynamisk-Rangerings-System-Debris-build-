using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS___Dynamisk_Rangerings_System.Models
{
    public class DRSDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            //Lokale DB for Mads.
            //options.UseSqlServer(@"Data Source=DESKTOP-R1NEBSS\SQLEXPRESS;Initial Catalog=DRSDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");

            //Lokale DB for Visual Studio.
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DRSDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");

        }

        public DbSet<Participant> Participants { get; set; }

    }
}
