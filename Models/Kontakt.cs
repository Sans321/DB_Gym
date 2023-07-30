using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Kontakt
    {
        public int Id { get; set; }
        public virtual Klient Klient { get; set; }
        public int KlientID { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}