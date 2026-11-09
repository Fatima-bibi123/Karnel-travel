using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KarnelTravelGuide.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resorts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Availability", "City", "ImageUrl", "Name", "PricePerNight", "Rating" },
                values: new object[,]
                {
                    { 1, true, "Karachi", "https://images.pexels.com/photos/6434592/pexels-photo-6434592.jpeg", "Pearl Continental Hotel", 18000m, 5 },
                    { 2, true, "Karachi", "https://images.pexels.com/photos/7507131/pexels-photo-7507131.jpeg", "Movenpick Hotel Karachi", 22000m, 5 },
                    { 3, true, "Karachi", "https://images.pexels.com/photos/2736384/pexels-photo-2736384.jpeg", "Avari Towers", 15000m, 4 },
                    { 4, true, "Lahore", "https://images.pexels.com/photos/6466496/pexels-photo-6466496.jpeg", "Avari Hotel Lahore", 16000m, 5 },
                    { 5, false, "Lahore", "https://images.pexels.com/photos/97083/pexels-photo-97083.jpeg", "Pearl Continental Lahore", 20000m, 5 },
                    { 6, true, "Lahore", "https://images.pexels.com/photos/6434592/pexels-photo-6434592.jpeg", "Nishat Hotel", 14000m, 4 },
                    { 7, true, "Islamabad", "https://images.pexels.com/photos/7507131/pexels-photo-7507131.jpeg", "Serena Hotel Islamabad", 25000m, 5 },
                    { 8, true, "Islamabad", "https://images.pexels.com/photos/6466496/pexels-photo-6466496.jpeg", "Islamabad Marriott Hotel", 21000m, 5 },
                    { 9, true, "Hunza Valley", "https://images.pexels.com/photos/2736384/pexels-photo-2736384.jpeg", "Hunza Serena Inn", 12000m, 4 },
                    { 10, true, "Hunza Valley", "https://images.pexels.com/photos/97083/pexels-photo-97083.jpeg", "Eagle's Nest Hotel", 9000m, 4 },
                    { 11, true, "Murree", "https://images.pexels.com/photos/6434592/pexels-photo-6434592.jpeg", "Bhurban Hotel", 13000m, 4 },
                    { 12, false, "Murree", "https://images.pexels.com/photos/7507131/pexels-photo-7507131.jpeg", "Grand Taj Hotel Murree", 7000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "Availability", "City", "ImageUrl", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, true, "Karachi", "https://images.pexels.com/photos/261181/pexels-photo-261181.jpeg", "Mubarak Village Beach Resort", 8000m, 4 },
                    { 2, true, "Karachi", "https://images.pexels.com/photos/635126/pexels-photo-635126.jpeg", "French Beach Resort", 10000m, 4 },
                    { 3, true, "Lahore", "https://images.pexels.com/photos/6821435/pexels-photo-6821435.jpeg", "Sukh Sagar Resort", 6000m, 3 },
                    { 4, true, "Lahore", "https://images.pexels.com/photos/14025857/pexels-photo-14025857.jpeg", "Royal Palm Resort", 12000m, 5 },
                    { 5, true, "Islamabad", "https://images.pexels.com/photos/5362213/pexels-photo-5362213.jpeg", "Lake View Resort", 9000m, 4 },
                    { 6, true, "Islamabad", "https://images.pexels.com/photos/261181/pexels-photo-261181.jpeg", "Margilla Resort", 11000m, 4 },
                    { 7, true, "Hunza Valley", "https://images.pexels.com/photos/635126/pexels-photo-635126.jpeg", "Eagle's Nest Resort", 15000m, 5 },
                    { 8, true, "Hunza Valley", "https://images.pexels.com/photos/6821435/pexels-photo-6821435.jpeg", "Hunza Darbar Resort", 13000m, 4 },
                    { 9, true, "Murree", "https://images.pexels.com/photos/14025857/pexels-photo-14025857.jpeg", "Bhurban Hill Resort", 10000m, 4 },
                    { 10, false, "Murree", "https://images.pexels.com/photos/5362213/pexels-photo-5362213.jpeg", "Pine Hills Resort", 7000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Availability", "City", "Cuisine", "ImageUrl", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, true, "Karachi", "Pakistani BBQ", "https://images.pexels.com/photos/12181619/pexels-photo-12181619.jpeg", "Kolachi Restaurant", 2500m, 5 },
                    { 2, true, "Karachi", "Traditional Pakistani", "https://images.pexels.com/photos/18601877/pexels-photo-18601877.jpeg", "Burns Road Food Street", 800m, 4 },
                    { 3, true, "Karachi", "BBQ & Grill", "https://images.pexels.com/photos/7627408/pexels-photo-7627408.jpeg", "BBQ Tonight", 2000m, 5 },
                    { 4, true, "Lahore", "Mughlai", "https://images.pexels.com/photos/33144658/pexels-photo-33144658.jpeg", "Haveli Restaurant", 3000m, 5 },
                    { 5, true, "Lahore", "Traditional Pakistani", "https://images.pexels.com/photos/6686367/pexels-photo-6686367.jpeg", "Food Street Gawalmandi", 600m, 4 },
                    { 6, true, "Lahore", "Continental", "https://images.pexels.com/photos/5083908/pexels-photo-5083908.jpeg", "Coco's Cubano", 2200m, 4 },
                    { 7, true, "Islamabad", "French Continental", "https://images.pexels.com/photos/6327536/pexels-photo-6327536.jpeg", "La Maison", 3500m, 5 },
                    { 8, true, "Islamabad", "Pakistani", "https://images.pexels.com/photos/7627408/pexels-photo-7627408.jpeg", "Tandoor Restaurant", 1800m, 4 },
                    { 9, true, "Hunza Valley", "Local Hunza Cuisine", "https://images.pexels.com/photos/12181619/pexels-photo-12181619.jpeg", "Hunza View Restaurant", 1200m, 4 },
                    { 10, true, "Hunza Valley", "Chinese & Pakistani", "https://images.pexels.com/photos/5083908/pexels-photo-5083908.jpeg", "Dragon Restaurant", 1500m, 3 },
                    { 11, true, "Murree", "Cafe & Fast Food", "https://images.pexels.com/photos/6327536/pexels-photo-6327536.jpeg", "Murree Hills Cafe", 900m, 4 },
                    { 12, false, "Murree", "Pakistani", "https://images.pexels.com/photos/33144658/pexels-photo-33144658.jpeg", "Pine View Restaurant", 1100m, 3 }
                });

            migrationBuilder.InsertData(
                table: "TouristSpots",
                columns: new[] { "Id", "Availability", "Category", "Description", "ImageUrl", "Location", "Name", "Price", "Rating" },
                values: new object[,]
                {
                    { 1, true, "Beach", "A stunning coastline along the Arabian Sea offering breathtaking sunset views, camel rides, and fresh seafood stalls. A favorite weekend getaway for Karachi residents.", "https://images.pexels.com/photos/16586186/pexels-photo-16586186.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Karachi", "Sea View Beach", 500m, 4 },
                    { 2, true, "Monument", "One of the largest mosques in the world, built in 1673 by Mughal Emperor Aurangzeb. A masterpiece of Mughal architecture with stunning red stone walls and marble domes.", "https://images.pexels.com/photos/31715009/pexels-photo-31715009.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Lahore", "Badshahi Mosque", 0m, 5 },
                    { 3, true, "Religious", "The largest mosque in Pakistan, designed by Turkish architect Vedat Dalokay. Its modern tent-like design blends Islamic architecture with contemporary styling against the Margalla Hills backdrop.", "https://images.pexels.com/photos/5258953/pexels-photo-5258953.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Islamabad", "Faisal Mosque", 0m, 5 },
                    { 4, true, "Natural", "A breathtaking mountain valley in the Gilgit-Baltistan region, surrounded by snow-capped peaks, terraced fields, and ancient forts. Famous for its apricot blossoms and hospitable people.", "https://images.pexels.com/photos/15916728/pexels-photo-15916728.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Hunza Valley", "Hunza Valley", 2000m, 5 },
                    { 5, true, "Hill Station", "A popular hill station known for its cool climate, lush green forests, and colonial-era architecture. Features scenic chairlifts, Mall Road shopping, and stunning mountain views.", "https://images.pexels.com/photos/13428934/pexels-photo-13428934.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Murree", "Murree Hills", 1500m, 4 },
                    { 6, true, "Beach", "A bustling beachfront with amusement parks, food stalls, and paddle boats. A lively spot for families and tourists looking to enjoy Karachi's coastal charm.", "https://images.pexels.com/photos/1544236/pexels-photo-1544236.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Karachi", "Clifton Beach", 300m, 4 },
                    { 7, true, "Historical", "A UNESCO World Heritage Site dating back to the Mughal era. The fort features stunning palaces, gardens, and the famous Sheesh Mahal (Palace of Mirrors).", "https://images.pexels.com/photos/14406067/pexels-photo-14406067.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Lahore", "Lahore Fort", 1000m, 5 },
                    { 8, true, "Natural", "A scenic viewpoint and hilltop garden in the Margalla Hills offering panoramic views of Islamabad. Features a mini zoo, walking trails, and restaurants.", "https://images.pexels.com/photos/15817294/pexels-photo-15817294.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Islamabad", "Daman-e-Koh", 200m, 4 },
                    { 9, true, "Natural", "A mesmerizing turquoise lake formed after a landslide in 2010. Offers boating, jet skiing, and stunning views of the surrounding Karakoram mountains.", "https://images.pexels.com/photos/19442083/pexels-photo-19442083.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Hunza Valley", "Attabad Lake", 2500m, 5 },
                    { 10, true, "Adventure", "The highest tourist point in Murree offering thrilling chairlift rides through dense pine forests with spectacular views of the Himalayan foothills.", "https://images.pexels.com/photos/17410793/pexels-photo-17410793.jpeg?auto=compress&cs=tinysrgb&h=650&w=940", "Murree", "Patriata Chairlift", 1800m, 4 }
                });

            migrationBuilder.InsertData(
                table: "TravelInfos",
                columns: new[] { "Id", "FromCity", "Price", "ToCity", "TransportType" },
                values: new object[,]
                {
                    { 1, "Karachi", 15000m, "Lahore", "Flight" },
                    { 2, "Karachi", 4500m, "Lahore", "Train" },
                    { 3, "Karachi", 3500m, "Lahore", "Bus" },
                    { 4, "Karachi", 18000m, "Islamabad", "Flight" },
                    { 5, "Karachi", 5500m, "Islamabad", "Train" },
                    { 6, "Karachi", 4000m, "Islamabad", "Bus" },
                    { 7, "Lahore", 8000m, "Islamabad", "Flight" },
                    { 8, "Lahore", 2000m, "Islamabad", "Bus" },
                    { 9, "Lahore", 2500m, "Islamabad", "Train" },
                    { 10, "Lahore", 3000m, "Murree", "Bus" },
                    { 11, "Lahore", 5000m, "Murree", "Car" },
                    { 12, "Islamabad", 800m, "Murree", "Bus" },
                    { 13, "Islamabad", 1500m, "Murree", "Car" },
                    { 14, "Islamabad", 25000m, "Hunza Valley", "Flight" },
                    { 15, "Islamabad", 8000m, "Hunza Valley", "Bus" },
                    { 16, "Islamabad", 12000m, "Hunza Valley", "Car" },
                    { 17, "Karachi", 20000m, "Murree", "Flight" },
                    { 18, "Karachi", 5000m, "Murree", "Bus" },
                    { 19, "Lahore", 28000m, "Hunza Valley", "Flight" },
                    { 20, "Lahore", 9000m, "Hunza Valley", "Bus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Resorts");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "TouristSpots");

            migrationBuilder.DropTable(
                name: "TravelInfos");
        }
    }
}
