using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class TypeGroup
    {
        public int Id { get; set; }
        public string NameGroup { get; set; }
        public int Nomer { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}