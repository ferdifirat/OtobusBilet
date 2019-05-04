using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Durak : BaseEntity
    {
        public string DurakAdi { get; set; }
        public virtual List<Rota> Rotalar { get; set; }
    }
}
