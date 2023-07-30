using BasseinProekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasseinProekta.Models
{
    public class KartaKlienta
    {
        public int Id { get; set; }
        public virtual Karta Karta { get; set; }
        public int KartaID { get; set; }
        public virtual Klient Klient { get; set; }
        public int KlientID { get; set; }
        public DateTime DateNachala { get; set; }
        public DateTime DateEnd { get; set; }
        public int NomerKartKlienta { get; set; }
        public virtual ICollection<Raspisanie> Raspisanies { get; set; }
        public virtual ICollection<Ychet> Ychets { get; set; }
        public virtual ICollection<ZanRti> ZanRtis { get; set; }
    }
}
