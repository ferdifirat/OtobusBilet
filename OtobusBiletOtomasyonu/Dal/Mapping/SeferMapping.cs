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
    public class SeferMapping : EntityTypeConfiguration<Sefer>
    {
        public SeferMapping()
        {
            ToTable("Seferler");
            HasKey(x => x.Id);

            HasRequired(x => x.Rota).WithMany(x => x.Seferler).HasForeignKey(x => x.RotaID);
            HasRequired(x => x.Otobus).WithMany(x => x.Seferler).HasForeignKey(x => x.OtobusID);

            

        }
    }
}
