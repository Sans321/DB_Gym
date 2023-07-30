using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual TypeGroup TypeGroup { get; set; }
        public int TypeGroupID { get; set; }
        public virtual ICollection<Trener> Treners { get; set; }

    }
}