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
    public class OtobusMapping : EntityTypeConfiguration<Otobus>
    {
        public OtobusMapping()
        {
            ToTable("Otobusler");
            HasKey(x => x.Id);
            HasRequired(x => x.OtobusTipi).WithMany(x => x.Otobusler).HasForeignKey(x => x.OtobusTipiID);


        }
    }
}
