using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Vanna
    {
        public int Id { get; set; }
        public virtual TypeVanna TypeVanna { get; set; }
        public int TypeVannaID { get; set; }
        public string NomerVanna { get; set; }
        public int Shirina { get; set; }
        public int Glubina { get; set; }
        public int Dlina { get; set; }
        public virtual ICollection<Raspisanie> Raspisanies { get; set; }
    }
}