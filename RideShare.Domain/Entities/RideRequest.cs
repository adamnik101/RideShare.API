namespace RideShare.Domain.Entities
{
    public class RideRequest : Entity
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int RideId { get; set; }
        public RideStatus Status { get; set; }
        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
        public virtual Ride Ride { get; set; }
    }
}