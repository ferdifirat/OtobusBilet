using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Koltuk : BaseEntity
    {
        public int KoltukNo { get; set; }
        public bool DoluMu { get; set; }
        public int OtobusID { get; set; }

        public virtual Otobus Otobus { get; set; }
    }
}
