using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Durak
    {
        public int DurakID { get; set; }
        public string DurakAdi { get; set; }

        public virtual List<RotaDurak> RotaDuraklar { get; set; }
    }
}
