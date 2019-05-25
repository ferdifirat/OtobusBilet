using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
     public class Kullanici
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string CitizienshipNumber { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int KullaniciTipiId { get; set; }

        
        public virtual KullaniciTipi KullaniciTipi { get; set; }
        public virtual List<Bilet> Biletler { get; set; }


    }
}
