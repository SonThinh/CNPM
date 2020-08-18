namespace KaraokeWeb.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string kind { get; set; }

        [Required]
        [StringLength(800)]
        public string images { get; set; }
    }
}
