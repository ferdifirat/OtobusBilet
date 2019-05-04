﻿using Data;
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

            //BU KISMA KENDİ CONNECTION STRING YAPINIZI EKLEYİNİZ !

            Database.Connection.ConnectionString = "server = .; database = OtobusBiletleriDb; trusted_connection=true";
            //Database.Connection.ConnectionString = "server = FIRAT; database = TrenBiletDb; Trusted_Connection = true;";

        }

        public DbSet<Bilet> Biletler { get; set; }
        public DbSet<Durak> Duraklar { get; set; }
        public DbSet<Koltuk> Koltuklar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciTip> KullaniciTipleri { get; set; }
        public DbSet<Sefer> Seferler { get; set; }
        public DbSet<Otobus> Otobusler { get; set; }
        public DbSet<OtobusTipi> OtobusTipleri { get; set; }
        public DbSet<Rota> Rotalar { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BiletMapping());
            modelBuilder.Configurations.Add(new DurakMapping());
            modelBuilder.Configurations.Add(new KoltukMapping());
            modelBuilder.Configurations.Add(new KullaniciMapping());
            modelBuilder.Configurations.Add(new KullaniciTipMapping());
            modelBuilder.Configurations.Add(new SeferMapping());
            modelBuilder.Configurations.Add(new OtobusMapping());
            modelBuilder.Configurations.Add(new OtobusTipMapping());
            modelBuilder.Configurations.Add(new RotaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
