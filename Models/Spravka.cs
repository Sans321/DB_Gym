using BasseinProekta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Spravka
    {
        public int Id { get; set; }
        public DateTime DateNachala { get; set; }
        public DateTime DateEnd { get; set; }
        public string GroupZdorovie { get; set; }
        public string Dopusk { get; set; }
        public virtual ICollection<Klient> Klients { get; set; }
        public virtual ICollection<KartaKlienta> KartaKlientas { get; set; }
    }
}