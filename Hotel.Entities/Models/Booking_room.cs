namespace Hotel.Entities.Models
{
    public class Booking_room : BaseEntity
    {
        public Guid ID_Room { get; set; }
        public virtual Room Room { get; set; }

        public DateTime Date_chek_in { get; set; }
        public DateTime Date_chek_out { get; set; }

        public Guid ID_Guest { get; set; }
        public virtual User User { get; set; }

    }
}
