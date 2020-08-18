namespace KaraokeWeb.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Drink")]
    public partial class Drink
    {
        [Key]
        public int drink_id { get; set; }

        [Required]
        [StringLength(200)]
        public string drink_name { get; set; }

        public int menu_id { get; set; }

        public decimal price { get; set; }

        public int status { get; set; }
    }
}
