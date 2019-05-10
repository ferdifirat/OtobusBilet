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
    public class KullaniciTipMapping : EntityTypeConfiguration<KullaniciTipi>
    {
        public KullaniciTipMapping()
        {
            ToTable("KullanıcıTipleri");
            Property(x => x.TipAdi).IsRequired();
            HasKey(x => x.Id);


        }
    }
}
