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
    public class DurakMapping : EntityTypeConfiguration<Durak>
    {
        public DurakMapping()
        {
            ToTable("Duraklar");

            Property(x => x.DurakAdi).IsRequired().HasMaxLength(30);


        }

    }
}
