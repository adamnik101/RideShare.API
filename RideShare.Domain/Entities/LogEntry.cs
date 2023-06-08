namespace RideShare.Domain.Entities
{
    public class LogEntry : Entity
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
    }
}