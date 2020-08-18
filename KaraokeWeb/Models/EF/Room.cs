namespace KaraokeWeb.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [Key]
        public int room_id { get; set; }

        public int kara_id { get; set; }

        [Required]
        [StringLength(100)]
        public string room_name { get; set; }

        public decimal price { get; set; }

        public int capacity { get; set; }

        [Required]
        [StringLength(200)]
        public string image { get; set; }

        public int status { get; set; }

        public int r_status { get; set; }
    }
}
