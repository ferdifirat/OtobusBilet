using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Durak
    {
        public int DurakID { get; set; }
        public string DurakAdi { get; set; }
        public virtual List<Rota> Rotalar { get; set; }
    }
}
