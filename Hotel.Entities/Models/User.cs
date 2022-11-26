namespace Hotel.Entities.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephon_number { get; set; }
        public string Passport_serries_and_number { get; set; }
        public bool admin { get; set; }

        public virtual ICollection<Booking_room> Booking_rooms { get; set; }

    }
}
