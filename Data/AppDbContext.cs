// AppDbContext - Entity Framework Core database context for KarnelTravelGuide - FIXED VERSION
using KarnelTravelGuide.Models;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelGuide.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TouristSpot> TouristSpots { get; set; }
        public DbSet<TravelInfo> TravelInfos { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; } 
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =====  Precision for decimal columns =====//
            modelBuilder.Entity<TouristSpot>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<TravelInfo>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Hotel>().Property(p => p.PricePerNight).HasPrecision(18, 2);
            modelBuilder.Entity<Restaurant>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Resort>().Property(p => p.Price).HasPrecision(18, 2);

            // ===== SEED DATA =====//
            modelBuilder.Entity<TouristSpot>().HasData(
                new TouristSpot { Id = 1, Name = "Sea View Beach", Location = "Karachi", Description = "A stunning coastline along the Arabian Sea offering breathtaking sunset views, camel rides, and fresh seafood stalls. A favorite weekend getaway for Karachi residents.", ImageUrl = "https://images.pexels.com/photos/16586186/pexels-photo-16586186.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Beach", Price = 500, Rating = 4, Availability = true },
                new TouristSpot { Id = 2, Name = "Badshahi Mosque", Location = "Lahore", Description = "One of the largest mosques in the world, built in 1673 by Mughal Emperor Aurangzeb. A masterpiece of Mughal architecture with stunning red stone walls and marble domes.", ImageUrl = "https://images.pexels.com/photos/31715009/pexels-photo-31715009.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Monument", Price = 0, Rating = 5, Availability = true },
                new TouristSpot { Id = 3, Name = "Faisal Mosque", Location = "Islamabad", Description = "The largest mosque in Pakistan, designed by Turkish architect Vedat Dalokay. Its modern tent-like design blends Islamic architecture with contemporary styling against the Margalla Hills backdrop.", ImageUrl = "https://images.pexels.com/photos/5258953/pexels-photo-5258953.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Religious", Price = 0, Rating = 5, Availability = true },
                new TouristSpot { Id = 4, Name = "Hunza Valley", Location = "Hunza Valley", Description = "A breathtaking mountain valley in the Gilgit-Baltistan region, surrounded by snow-capped peaks, terraced fields, and ancient forts. Famous for its apricot blossoms and hospitable people.", ImageUrl = "https://images.pexels.com/photos/15916728/pexels-photo-15916728.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Natural", Price = 2000, Rating = 5, Availability = true },
                new TouristSpot { Id = 5, Name = "Murree Hills", Location = "Murree", Description = "A popular hill station known for its cool climate, lush green forests, and colonial-era architecture. Features scenic chairlifts, Mall Road shopping, and stunning mountain views.", ImageUrl = "https://images.pexels.com/photos/13428934/pexels-photo-13428934.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Hill Station", Price = 1500, Rating = 4, Availability = true },
                new TouristSpot { Id = 6, Name = "Clifton Beach", Location = "Karachi", Description = "A bustling beachfront with amusement parks, food stalls, and paddle boats. A lively spot for families and tourists looking to enjoy Karachi's coastal charm.", ImageUrl = "https://images.pexels.com/photos/1544236/pexels-photo-1544236.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Beach", Price = 300, Rating = 4, Availability = true },
                new TouristSpot { Id = 7, Name = "Lahore Fort", Location = "Lahore", Description = "A UNESCO World Heritage Site dating back to the Mughal era. The fort features stunning palaces, gardens, and the famous Sheesh Mahal (Palace of Mirrors).", ImageUrl = "https://images.pexels.com/photos/14406067/pexels-photo-14406067.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Historical", Price = 1000, Rating = 5, Availability = true },
                new TouristSpot { Id = 8, Name = "Daman-e-Koh", Location = "Islamabad", Description = "A scenic viewpoint and hilltop garden in the Margalla Hills offering panoramic views of Islamabad. Features a mini zoo, walking trails, and restaurants.", ImageUrl = "https://images.pexels.com/photos/15817294/pexels-photo-15817294.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Natural", Price = 200, Rating = 4, Availability = true },
                new TouristSpot { Id = 9, Name = "Attabad Lake", Location = "Hunza Valley", Description = "A mesmerizing turquoise lake formed after a landslide in 2010. Offers boating, jet skiing, and stunning views of the surrounding Karakoram mountains.", ImageUrl = "https://images.pexels.com/photos/19442083/pexels-photo-19442083.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Natural", Price = 2500, Rating = 5, Availability = true },
                new TouristSpot { Id = 10, Name = "Patriata Chairlift", Location = "Murree", Description = "The highest tourist point in Murree offering thrilling chairlift rides through dense pine forests with spectacular views of the Himalayan foothills.", ImageUrl = "https://images.pexels.com/photos/17410793/pexels-photo-17410793.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", Category = "Adventure", Price = 1800, Rating = 4, Availability = true }
            );

            modelBuilder.Entity<TravelInfo>().HasData(
                new TravelInfo { Id = 1, FromCity = "Karachi", ToCity = "Lahore", TransportType = "Flight", Price = 15000 },
                new TravelInfo { Id = 2, FromCity = "Karachi", ToCity = "Lahore", TransportType = "Train", Price = 4500 },
                new TravelInfo { Id = 3, FromCity = "Karachi", ToCity = "Lahore", TransportType = "Bus", Price = 3500 },
                new TravelInfo { Id = 4, FromCity = "Karachi", ToCity = "Islamabad", TransportType = "Flight", Price = 18000 },
                new TravelInfo { Id = 5, FromCity = "Karachi", ToCity = "Islamabad", TransportType = "Train", Price = 5500 },
                new TravelInfo { Id = 6, FromCity = "Karachi", ToCity = "Islamabad", TransportType = "Bus", Price = 4000 },
                new TravelInfo { Id = 7, FromCity = "Lahore", ToCity = "Islamabad", TransportType = "Flight", Price = 8000 },
                new TravelInfo { Id = 8, FromCity = "Lahore", ToCity = "Islamabad", TransportType = "Bus", Price = 2000 },
                new TravelInfo { Id = 9, FromCity = "Lahore", ToCity = "Islamabad", TransportType = "Train", Price = 2500 },
                new TravelInfo { Id = 10, FromCity = "Lahore", ToCity = "Murree", TransportType = "Bus", Price = 3000 },
                new TravelInfo { Id = 11, FromCity = "Lahore", ToCity = "Murree", TransportType = "Car", Price = 5000 },
                new TravelInfo { Id = 12, FromCity = "Islamabad", ToCity = "Murree", TransportType = "Bus", Price = 800 },
                new TravelInfo { Id = 13, FromCity = "Islamabad", ToCity = "Murree", TransportType = "Car", Price = 1500 },
                new TravelInfo { Id = 14, FromCity = "Islamabad", ToCity = "Hunza Valley", TransportType = "Flight", Price = 25000 },
                new TravelInfo { Id = 15, FromCity = "Islamabad", ToCity = "Hunza Valley", TransportType = "Bus", Price = 8000 },
                new TravelInfo { Id = 16, FromCity = "Islamabad", ToCity = "Hunza Valley", TransportType = "Car", Price = 12000 },
                new TravelInfo { Id = 17, FromCity = "Karachi", ToCity = "Murree", TransportType = "Flight", Price = 20000 },
                new TravelInfo { Id = 18, FromCity = "Karachi", ToCity = "Murree", TransportType = "Bus", Price = 5000 },
                new TravelInfo { Id = 19, FromCity = "Lahore", ToCity = "Hunza Valley", TransportType = "Flight", Price = 28000 },
                new TravelInfo { Id = 20, FromCity = "Lahore", ToCity = "Hunza Valley", TransportType = "Bus", Price = 9000 }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Pearl Continental Hotel", City = "Karachi", PricePerNight = 18000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/6434592/pexels-photo-6434592.jpeg", Availability = true },
                new Hotel { Id = 2, Name = "Movenpick Hotel Karachi", City = "Karachi", PricePerNight = 22000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/7507131/pexels-photo-7507131.jpeg", Availability = true },
                new Hotel { Id = 3, Name = "Avari Towers", City = "Karachi", PricePerNight = 15000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/2736384/pexels-photo-2736384.jpeg", Availability = true },
                new Hotel { Id = 4, Name = "Avari Hotel Lahore", City = "Lahore", PricePerNight = 16000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/6466496/pexels-photo-6466496.jpeg", Availability = true },
                new Hotel { Id = 5, Name = "Pearl Continental Lahore", City = "Lahore", PricePerNight = 20000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/97083/pexels-photo-97083.jpeg", Availability = false },
                new Hotel { Id = 6, Name = "Nishat Hotel", City = "Lahore", PricePerNight = 14000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/6434592/pexels-photo-6434592.jpeg", Availability = true },
                new Hotel { Id = 7, Name = "Serena Hotel Islamabad", City = "Islamabad", PricePerNight = 25000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/7507131/pexels-photo-7507131.jpeg", Availability = true },
                new Hotel { Id = 8, Name = "Islamabad Marriott Hotel", City = "Islamabad", PricePerNight = 21000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/6466496/pexels-photo-6466496.jpeg", Availability = true },
                new Hotel { Id = 9, Name = "Hunza Serena Inn", City = "Hunza Valley", PricePerNight = 12000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/2736384/pexels-photo-2736384.jpeg", Availability = true },
                new Hotel { Id = 10, Name = "Eagle's Nest Hotel", City = "Hunza Valley", PricePerNight = 9000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/97083/pexels-photo-97083.jpeg", Availability = true },
                new Hotel { Id = 11, Name = "Bhurban Hotel", City = "Murree", PricePerNight = 13000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/6434592/pexels-photo-6434592.jpeg", Availability = true },
                new Hotel { Id = 12, Name = "Grand Taj Hotel Murree", City = "Murree", PricePerNight = 7000, Rating = 3, ImageUrl = "https://images.pexels.com/photos/7507131/pexels-photo-7507131.jpeg", Availability = false }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Kolachi Restaurant", City = "Karachi", Cuisine = "Pakistani BBQ", Price = 2500, Rating = 5, ImageUrl = "https://images.pexels.com/photos/12181619/pexels-photo-12181619.jpeg", Availability = true },
                new Restaurant { Id = 2, Name = "Burns Road Food Street", City = "Karachi", Cuisine = "Traditional Pakistani", Price = 800, Rating = 4, ImageUrl = "https://images.pexels.com/photos/18601877/pexels-photo-18601877.jpeg", Availability = true },
                new Restaurant { Id = 3, Name = "BBQ Tonight", City = "Karachi", Cuisine = "BBQ & Grill", Price = 2000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/7627408/pexels-photo-7627408.jpeg", Availability = true },
                new Restaurant { Id = 4, Name = "Haveli Restaurant", City = "Lahore", Cuisine = "Mughlai", Price = 3000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/33144658/pexels-photo-33144658.jpeg", Availability = true },
                new Restaurant { Id = 5, Name = "Food Street Gawalmandi", City = "Lahore", Cuisine = "Traditional Pakistani", Price = 600, Rating = 4, ImageUrl = "https://images.pexels.com/photos/6686367/pexels-photo-6686367.jpeg", Availability = true },
                new Restaurant { Id = 6, Name = "Coco's Cubano", City = "Lahore", Cuisine = "Continental", Price = 2200, Rating = 4, ImageUrl = "https://images.pexels.com/photos/5083908/pexels-photo-5083908.jpeg", Availability = true },
                new Restaurant { Id = 7, Name = "La Maison", City = "Islamabad", Cuisine = "French Continental", Price = 3500, Rating = 5, ImageUrl = "https://images.pexels.com/photos/6327536/pexels-photo-6327536.jpeg", Availability = true },
                new Restaurant { Id = 8, Name = "Tandoor Restaurant", City = "Islamabad", Cuisine = "Pakistani", Price = 1800, Rating = 4, ImageUrl = "https://images.pexels.com/photos/7627408/pexels-photo-7627408.jpeg", Availability = true },
                new Restaurant { Id = 9, Name = "Hunza View Restaurant", City = "Hunza Valley", Cuisine = "Local Hunza Cuisine", Price = 1200, Rating = 4, ImageUrl = "https://images.pexels.com/photos/12181619/pexels-photo-12181619.jpeg", Availability = true },
                new Restaurant { Id = 10, Name = "Dragon Restaurant", City = "Hunza Valley", Cuisine = "Chinese & Pakistani", Price = 1500, Rating = 3, ImageUrl = "https://images.pexels.com/photos/5083908/pexels-photo-5083908.jpeg", Availability = true },
                new Restaurant { Id = 11, Name = "Murree Hills Cafe", City = "Murree", Cuisine = "Cafe & Fast Food", Price = 900, Rating = 4, ImageUrl = "https://images.pexels.com/photos/6327536/pexels-photo-6327536.jpeg", Availability = true },
                new Restaurant { Id = 12, Name = "Pine View Restaurant", City = "Murree", Cuisine = "Pakistani", Price = 1100, Rating = 3, ImageUrl = "https://images.pexels.com/photos/33144658/pexels-photo-33144658.jpeg", Availability = false }
            );

            modelBuilder.Entity<Resort>().HasData(
                new Resort { Id = 1, Name = "Mubarak Village Beach Resort", City = "Karachi", Price = 8000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/261181/pexels-photo-261181.jpeg", Availability = true },
                new Resort { Id = 2, Name = "French Beach Resort", City = "Karachi", Price = 10000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/635126/pexels-photo-635126.jpeg", Availability = true },
                new Resort { Id = 3, Name = "Sukh Sagar Resort", City = "Lahore", Price = 6000, Rating = 3, ImageUrl = "https://images.pexels.com/photos/6821435/pexels-photo-6821435.jpeg", Availability = true },
                new Resort { Id = 4, Name = "Royal Palm Resort", City = "Lahore", Price = 12000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/14025857/pexels-photo-14025857.jpeg", Availability = true },
                new Resort { Id = 5, Name = "Lake View Resort", City = "Islamabad", Price = 9000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/5362213/pexels-photo-5362213.jpeg", Availability = true },
                new Resort { Id = 6, Name = "Margilla Resort", City = "Islamabad", Price = 11000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/261181/pexels-photo-261181.jpeg", Availability = true },
                new Resort { Id = 7, Name = "Eagle's Nest Resort", City = "Hunza Valley", Price = 15000, Rating = 5, ImageUrl = "https://images.pexels.com/photos/635126/pexels-photo-635126.jpeg", Availability = true },
                new Resort { Id = 8, Name = "Hunza Darbar Resort", City = "Hunza Valley", Price = 13000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/6821435/pexels-photo-6821435.jpeg", Availability = true },
                new Resort { Id = 9, Name = "Bhurban Hill Resort", City = "Murree", Price = 10000, Rating = 4, ImageUrl = "https://images.pexels.com/photos/14025857/pexels-photo-14025857.jpeg", Availability = true },
                new Resort { Id = 10, Name = "Pine Hills Resort", City = "Murree", Price = 7000, Rating = 3, ImageUrl = "https://images.pexels.com/photos/5362213/pexels-photo-5362213.jpeg", Availability = false }
            );
        }
    }
}