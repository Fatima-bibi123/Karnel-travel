namespace KarnelTravelGuide.Models
{
    public class TravelInfo
    {
        public int Id { get; set; }
        public string FromCity { get; set; } = string.Empty;
        public string ToCity { get; set; } = string.Empty;
        public string TransportType { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}