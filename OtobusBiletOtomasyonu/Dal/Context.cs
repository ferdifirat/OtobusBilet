using Dal.Mapping;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Context : DbContext
    {
        public Context()
        {

            

            Database.Connection.ConnectionString = "server = .; database = OtobusBiletlerDb8; trusted_connection=true";
           

        }

        public DbSet<Bilet> Biletler { get; set; }
        public DbSet<Durak> Duraklar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciTipi> KullaniciTipleri { get; set; }
        public DbSet<Sefer> Seferler { get; set; }
        public DbSet<Otobus> Otobusler { get; set; }
        public DbSet<OtobusTipi> OtobusTipleri { get; set; }
        public DbSet<Rota> Rotalar { get; set; }
        public DbSet<RotaDurak> RotaDuraklar { get; set; }
        public DbSet<Fiyat> Fiyatlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BiletMapping());
            modelBuilder.Configurations.Add(new DurakMapping());
            modelBuilder.Configurations.Add(new KullaniciMapping());
            modelBuilder.Configurations.Add(new KullaniciTipMapping());
            modelBuilder.Configurations.Add(new SeferMapping());
            modelBuilder.Configurations.Add(new OtobusMapping());
            modelBuilder.Configurations.Add(new OtobusTipMapping());
            modelBuilder.Configurations.Add(new RotaMapping());
            modelBuilder.Configurations.Add(new RotaDurakMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
