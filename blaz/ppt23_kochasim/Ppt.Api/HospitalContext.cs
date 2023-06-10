using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Collections.Generic;

namespace Ppt.Api
{
    public class HospitalContext : DbContext
    {
        public DbSet<VybaveniVm> HospitalEquipment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db/database.db");
        }
    }
}

