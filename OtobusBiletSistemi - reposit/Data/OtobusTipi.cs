﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OtobusTipi
    {
        public int OtobusTipiID { get; set; }
        public int TipAdi { get; set; }

        public virtual List<Otobus> Otobusler { get; set; }
       
    }
}