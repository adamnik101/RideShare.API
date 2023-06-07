namespace RideShare.Domain.Entities
{
    public class Rating : Entity
    {
        public string Description { get; set; }
        public int Score { get; set; }
    }
}