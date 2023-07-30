using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class TypeTrener
    {
        public int Id { get; set; }
        public string Programma { get; set; }
        public string Personal { get; set; }
        public virtual ICollection<Trener> Treners { get; set; }
    }
}