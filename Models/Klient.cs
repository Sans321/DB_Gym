using BasseinProekta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Klient
    {
        public int Id { get; set; }
        public virtual Spravka Spravka { get; set; }
        public int SpravkaID { get; set; }
        public string FamiliR { get; set; }
        public string ImR { get; set; }
        public string Otchestvo { get; set; }
        public int SeriaPasport { get; set; }
        public int NomerPasporta { get; set; }
        public virtual ICollection<KartaKlienta> KartaKlientas { get; set; }
    }
}