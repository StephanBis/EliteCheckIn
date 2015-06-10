using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class Systems
    {
        public int Id { get; set; }
        public int SystemId { get; set; }
        public string Name { get; set; }
        public string Faction { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public string Population { get; set; }
        public string Government { get; set; }
        public string Allegiance { get; set; }
        public string State { get; set; }
        public string Security { get; set; }
        public string Primary_economy { get; set; }
        public string Needs_permit { get; set; }
    }
}