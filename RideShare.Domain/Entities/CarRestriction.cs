namespace RideShare.Domain.Entities
{
    public class CarRestriction
    {
        public int CarId { get; set; }
        public int RestrictionId { get; set; }

        public Car Car { get; set; }
        public Restriction Restriction { get; set; }
    }
}