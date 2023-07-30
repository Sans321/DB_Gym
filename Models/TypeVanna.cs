using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class TypeVanna
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Forma { get; set; }
        public virtual ICollection<Vanna> Vanas { get; set; }
    }
}