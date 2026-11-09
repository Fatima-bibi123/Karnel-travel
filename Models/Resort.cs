namespace KarnelTravelGuide.Models
{
    public class Resort
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool Availability { get; set; }
    }
}