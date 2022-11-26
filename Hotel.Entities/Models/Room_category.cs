namespace Hotel.Entities.Models
{
    public class Room_category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
