using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Fiyat
    {
        public int Id { get; set; }
        public int KalkisId { get; set; }
        public int VarisId { get; set; }
        public int Tutar { get; set; }

    }
}
