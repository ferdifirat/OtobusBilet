using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Sefer
    {
        public int Id { get; set; }
        public int RotaID { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName="time")]
        public TimeSpan CikisSaati { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan VarisSaati { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan SeferSuresi { get; set; }
        public int OtobusID { get; set; }

        public virtual List<Bilet> Biletler { get; set; }
        public virtual Rota Rota { get; set; }
        public virtual Otobus Otobus { get; set; }

    }
}
