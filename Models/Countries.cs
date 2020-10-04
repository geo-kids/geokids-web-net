using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_kids_web_net.Models
{
    [Table("vw_countries")]
    public class Countries
    {
        [Key]
        public string country_id { get; set; }
        public string country { get; set; }
        public string un_m49 {get; set; }
        public int region_id {get; set; }
        public string flag { get; set; }
    }
}