using BasseinProekta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class ZanRti
    {
        public int Id { get; set; }
        public virtual KartaKlienta KartaKlienta { get; set; }
        public int KartaKlientaID { get; set; }
        public virtual TypeZanRti TypeZanRti { get; set; }
        public int TypeZanRtiID { get; set; }
        public int Cena { get; set; }
    }
}