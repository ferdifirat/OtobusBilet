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
    public class OtobusTipMapping : EntityTypeConfiguration<OtobusTipi>
    {
        public OtobusTipMapping()
        {
            ToTable("OtobusTipleri");
            HasKey(x => x.Id);

        }
    }
}
