========================================
KarnelTravelGuide - FIXED PROJECT
========================================

WHAT WAS FIXED:
1. TouristSpot model now has: Id, Name, Location, Description, ImageUrl, Category, Price, Rating, Availability
2. Hotel, Restaurant, Resort models updated with Price/Rating/Availability for search filters
3. Home page Featured Tourist Spots shows EXACTLY 6 cards (Take(6) + col-md-4 = 2 rows of 3)
4. Seed data includes 10 tourist spots (enough for 6 featured)
5. Search supports location + minPrice + maxPrice + minRating + availableOnly (Advanced Search panel)
6. Program.cs no longer uses EnsureDeleted/EnsureCreated (migration-friendly)
7. launchSettings.json set with http://www.Karneltravelguide.com
8. Comments added throughout
9. Target framework set to net8.0 with matching EF Core 8 packages
10. No Migrations folder included - you create a clean one

========================================
HOW TO RUN (Package Manager Console):
========================================

1. Open the solution / project in Visual Studio
2. Open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
3. Make sure the Default project is KarnelTravelGuide
4. Run these commands ONE BY ONE:

   PM> Drop-Database
   PM> Add-Migration Initial
   PM> Update-Database

5. Press F5 to run the application.

If Drop-Database fails (no database yet), just run Add-Migration Initial then Update-Database.

========================================
MENU PAGES:
========================================
- Home
- Search (with Advanced Search)
- Tourist Spots
- Hotels
- Restaurants
- Resorts
- Travel Info
- About
- Contact

========================================
