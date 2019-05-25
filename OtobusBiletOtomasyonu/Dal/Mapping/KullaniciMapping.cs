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
    public class KullaniciMapping : EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMapping()
        {
            ToTable("Kullanıcılar");
            HasKey(x => x.Id);
           
            HasRequired(x => x.KullaniciTipi).WithMany(x => x.Kullanicilar).HasForeignKey(x => x.KullaniciTipiId);

           

        }
    }
}
