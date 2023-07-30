using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Trener
    {
        public int Id { get; set; }
        public string FamiliR { get; set; }
        public string ImR { get; set; }
        public string Otchestvo { get; set; }
        public virtual Group Group { get; set; }
        public int GroupID { get; set; }
        public virtual TypeTrener TypeTrener { get; set; }
        public int TypeTrenerID { get; set; }
        public virtual ICollection<Raspisanie> Raspisanies { get; set; }
    }
}