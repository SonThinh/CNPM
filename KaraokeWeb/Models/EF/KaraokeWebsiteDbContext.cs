namespace KaraokeWeb.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KaraokeWebsiteDbContext : DbContext
    {
        public KaraokeWebsiteDbContext()
            : base("name=KaraokeWebsite")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Karaoke> Karaokes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Drink_Detail> Drink_Detail { get; set; }
        public virtual DbSet<Food_Detail> Food_Detail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.user_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bill>()
                .Property(e => e.total_room)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Bill>()
                .Property(e => e.total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Drink>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Food>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Karaoke>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Karaoke>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Room>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Drink_Detail>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Drink_Detail>()
                .Property(e => e.total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Food_Detail>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Food_Detail>()
                .Property(e => e.total)
                .HasPrecision(18, 0);
        }
    }
}
