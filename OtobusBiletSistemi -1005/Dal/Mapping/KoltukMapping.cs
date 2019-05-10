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
    public class KoltukMapping : EntityTypeConfiguration<Koltuk>
    {
        public KoltukMapping()
        {
            ToTable("Koltuklar");
            Property(x => x.KoltukNo).IsRequired();
            HasRequired(x => x.Otobus).WithMany(x => x.Koltuklar).HasForeignKey(x => x.OtobusID);
        }

    }
}
