namespace KaraokeWeb.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        public int bill_id { get; set; }

        [Required]
        [StringLength(10)]
        public string user_phone { get; set; }

        public int room_id { get; set; }

        public int id_staff { get; set; }

        public int used_time { get; set; }

        public DateTime created_at { get; set; }

        public int status { get; set; }

        public decimal price { get; set; }

        public decimal total_room { get; set; }

        public decimal total { get; set; }
    }
}
