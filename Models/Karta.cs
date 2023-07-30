using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasseinProekt.Models
{
    public class Karta
    {
        public int Id { get; set; }
        public DateTime DateNachala { get; set; }
        public DateTime DateEnd { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}