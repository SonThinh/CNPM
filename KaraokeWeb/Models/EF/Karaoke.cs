namespace KaraokeWeb.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Karaoke")]
    public partial class Karaoke
    {
        [Key]
        public int kara_id { get; set; }

        [Required]
        [StringLength(200)]
        public string kara_name { get; set; }

        [Required]
        [StringLength(200)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [Required]
        [StringLength(200)]
        public string images { get; set; }
    }
}
