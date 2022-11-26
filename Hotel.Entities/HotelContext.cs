using Hotel.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Entities
{
    public class HotelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Booking_room> Booking_rooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Room_category> Room_categoryes { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Users

            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(x => x.Id);

            #endregion

            #region Booking_rooms

            builder.Entity<Booking_room>().ToTable("booking_rooms");
            builder.Entity<Booking_room>().HasKey(x => x.Id);

            builder.Entity<Booking_room>().HasOne(x => x.User)
                                            .WithMany(x => x.Booking_rooms)
                                            .HasForeignKey(x => x.ID_Guest)
                                            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking_room>().HasOne(x => x.Room)
                                            .WithMany(x => x.Booking_rooms)
                                            .HasForeignKey(x => x.ID_Room)
                                            .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Rooms

            builder.Entity<Room>().ToTable("rooms");
            builder.Entity<Room>().HasKey(x => x.Id);

            builder.Entity<Room>().HasOne(x => x.Room_categoryes)
                                    .WithMany(x => x.Rooms)
                                    .HasForeignKey(x => x.ID_Category)
                                    .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Room_categoryes

            builder.Entity<Room_category>().ToTable("room_categories");
            builder.Entity<Room_category>().HasKey(x => x.Id);

            #endregion
        }
    }
}
