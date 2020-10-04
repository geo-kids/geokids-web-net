using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_kids_web_net.Models
{
    [Table("vw_regions")]
    public class Regions
    {
        [Key]
        public int region_id { get; set; }
        public string region { get; set; }
        public int continent_id { get; set; }
    }
}