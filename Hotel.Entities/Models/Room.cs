namespace Hotel.Entities.Models
{
    public class Room : BaseEntity
    {
        public Guid ID_Category { get; set; }
        public virtual Room_category Room_categoryes { get; set; }

        public int Capacity { get; set; }
        public int Number { get; set; }
        public int Price_per_day { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Booking_room> Booking_rooms { get; set; }
    }
}
