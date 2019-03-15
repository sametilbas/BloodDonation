using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KBP.Models
{
    public class OurDbContext:DbContext
    {
        public OurDbContext():base("identity")
        {
            Database.SetInitializer<OurDbContext>(new DropCreateDatabaseIfModelChanges<OurDbContext>());
        }
        
        public DbSet<UyeAccount> uyeAccount { get; set; }
        public DbSet<HastaneAccount> hastaneAccounts { get; set; }
        public DbSet<KanMerkeziAccount> kanMerkeziAccounts { get; set; }
        public DbSet<Duyuru> duyurus { get; set; }
        public DbSet<Stok> stoks { get; set; }
        public DbSet<Kan> kans { get; set; }
    }
}