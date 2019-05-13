using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RotaDurak
    {
        public int Id { get; set; }
        public int RotaID { get; set; }
        public int DurakID { get; set; }
        public int Order { get; set; }

        public virtual Rota Rota { get; set; }
        public virtual Durak Durak { get; set; }
    }
}
