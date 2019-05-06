using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class BiletMapping : EntityTypeConfiguration<Bilet>
    {
        public BiletMapping()
        {
            ToTable("Biletler");
            HasKey(x => x.Id);
            
            Property(x => x.Fiyat).IsRequired();
            HasRequired(x => x.Sefer).WithMany(x => x.Biletler).HasForeignKey(x => x.SeferID);
            HasRequired(x => x.Kullanici).WithMany(x => x.Biletler).HasForeignKey(x => x.KullaniciID);
        }
    }
}
