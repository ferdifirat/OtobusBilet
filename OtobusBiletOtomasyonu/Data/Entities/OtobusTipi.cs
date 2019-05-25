using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OtobusTipi
    {
        public int Id { get; set; }
        public string TipAdi { get; set; }

        public virtual List<Otobus> Otobusler { get; set; }

    }
}
