using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_kids_web_net.Models
{
    [Table("vw_continents")]
    public class Continents
    {
        [Key]
        public int continent_id { get; set; }
        public string continent { get; set; }
    }
}