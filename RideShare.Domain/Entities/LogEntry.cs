namespace RideShare.Domain.Entities
{
    public class LogEntry : Entity
    {
        public int ActorId { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
    }
}