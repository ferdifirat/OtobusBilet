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
    public class RotaMapping : EntityTypeConfiguration<Rota>
    {
        public RotaMapping()
        {
            ToTable("Rotalar");
            HasKey(x => x.Id);


        }


    }
}
