using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mapping
{
     public class RotaDurakMapping : EntityTypeConfiguration<RotaDurak>
    {
        public RotaDurakMapping()
        {
            ToTable("RotaDuraklar");
            HasKey(x => x.Id);

            HasRequired(x => x.Durak).WithMany(x => x.RotaDuraklar).HasForeignKey(x => x.DurakID);
            HasRequired(x => x.Rota).WithMany(x => x.RotaDuraklar).HasForeignKey(x => x.RotaID);

        }
    }
}
