using BasseinProekta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Ychet
    {
        public int Id { get; set; }
        public int Balance { get; set; }
        public virtual KartaKlienta KartaKlienta { get; set; }
        public int KartaKlientaID { get; set; }
    }
}