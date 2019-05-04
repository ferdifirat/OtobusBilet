using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Otobus
    {
        public int OtobusID { get; set; }
        public int OtobusTipiID { get; set; }
        public int KoltukSayisi { get; set; }

        public virtual List<Sefer> Seferler { get; set; }
        public virtual OtobusTipi OtobusTipi { get; set; }
        public virtual List<Koltuk> Koltuklar { get; set; }

    }
}
