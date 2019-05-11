using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Rota
    {
        public int Id { get; set; }
        public int CikisID { get; set; }
        public int VarisID { get; set; }

        public virtual List<Sefer> Seferler { get; set; }
        public virtual List<RotaDurak> RotaDuraklar { get; set; }
    }
}
