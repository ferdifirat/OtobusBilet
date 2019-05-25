using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Bilet
    {
        public int Id { get; set; }
        public bool BiletDurumu { get; set; }
        public bool YemekliMi { get; set; }
        public bool CocukluMu { get; set; }
        public bool SigortaliMi { get; set; }
        public bool YolculukHizmetiVarMi { get; set; }
        public int SeferID { get; set; }
        public int KullaniciID { get; set; }
        public float Fiyat { get; set; }
        public int KoltukNo { get; set; }


        public virtual Kullanici Kullanici { get; set; }
        public virtual Sefer Sefer { get; set; }
    }
}
