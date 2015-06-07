using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend
{
    [Table("SystemsTest")]
    public class Systems
    {
        [Key]
        public int SystemId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faction { get; set; }
    }
}