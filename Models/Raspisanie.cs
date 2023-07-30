using BasseinProekta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Raspisanie
    {
        public int Id { get; set; }
        public virtual KartaKlienta KartaKlienta { get; set; }
        public int KartaKlientaID { get; set; }
        public virtual Trener Trener { get; set; }
        public int TrenerID { get; set; }
        public virtual Vanna Vanna { get; set; }
        public int VannaID { get; set; }
        public DateTime DateNachala { get; set; }
        public DateTime DateEnd { get; set; }
    }
}