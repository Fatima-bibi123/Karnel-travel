using KarnelTravelGuide.Data;
using KarnelTravelGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarnelTravelGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context) { _context = context; }

        // ===== LOCK SYSTEM =====//
        private bool IsUserLoggedIn()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var role = HttpContext.Session.GetString("Role");
            var admin = HttpContext.Session.GetString("AdminLoggedIn");
            return !string.IsNullOrEmpty(userId) || !string.IsNullOrEmpty(role) || admin == "true";
        }
        // =======================

        public IActionResult Index()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            ViewBag.SliderSpots = _context.TouristSpots.Take(5).ToList();
            ViewBag.FeaturedSpots = _context.TouristSpots.Take(6).ToList();
            ViewBag.Hotels = _context.Hotels.Take(4).ToList();
            ViewBag.Restaurants = _context.Restaurants.Take(4).ToList();
            return View();
        }

        public IActionResult TouristSpots()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View(_context.TouristSpots.ToList());
        }
        public IActionResult Hotels()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View(_context.Hotels.ToList());
        }
        public IActionResult Restaurants()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View(_context.Restaurants.ToList());
        }
        public IActionResult Resorts()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View(_context.Resorts.ToList());
        }
        public IActionResult TravelInfo()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View(_context.TravelInfos.ToList());
        }

        // YEH 2 PAGES LOCKED HAIN //
        public IActionResult About()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View();
        }
        public IActionResult Contact()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactMessage model)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            try { model.CreatedAt = DateTime.Now; _context.ContactMessages.Add(model); await _context.SaveChangesAsync(); TempData["ContactSuccess"] = "Message sent successfully!"; }
            catch (Exception ex) { TempData["ContactSuccess"] = "Error: " + (ex.InnerException?.Message ?? ex.Message); }
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedback(Feedback model)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            try { model.CreatedAt = DateTime.Now; _context.Feedbacks.Add(model); await _context.SaveChangesAsync(); TempData["FeedbackSuccess"] = "Thank you for your feedback!"; }
            catch (Exception ex) { TempData["FeedbackSuccess"] = "Error: " + (ex.InnerException?.Message ?? ex.Message); }
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order model)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            try
            {
                model.CreatedAt = DateTime.Now;
                _context.Orders.Add(model);
                await _context.SaveChangesAsync();
                TempData["OrderSuccess"] = "Your order for " + model.OrderType + " has been placed successfully! We will contact you soon.";
            }
            catch (Exception ex)
            {
                TempData["OrderSuccess"] = "Error: " + (ex.InnerException?.Message ?? ex.Message);
            }
            return RedirectToAction("Contact");
        }

        public IActionResult Information()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            ViewBag.TouristSpots = _context.TouristSpots.OrderByDescending(t => t.Id).Take(4).ToList();
            ViewBag.NewHotels = _context.Hotels.OrderByDescending(h => h.Id).Take(4).ToList();
            ViewBag.NewRestaurants = _context.Restaurants.OrderByDescending(r => r.Id).Take(4).ToList();
            ViewBag.NewResorts = _context.Resorts.OrderByDescending(r => r.Id).Take(4).ToList();
            ViewBag.Packages = new List<dynamic> {
                new { Name = "Hunza Valley Explorer", Days = "5 Days / 4 Nights", Price = 45000, Discount = "20% OFF", City = "Hunza" },
                new { Name = "Murree Honeymoon Package", Days = "3 Days / 2 Nights", Price = 25000, Discount = "15% OFF", City = "Murree" },
                new { Name = "Karachi Beach Tour", Days = "2 Days / 1 Night", Price = 12000, Discount = "10% OFF", City = "Karachi" }
            };
            return View();
        }

        public IActionResult Search(string location)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            ViewBag.HasSearched = !string.IsNullOrEmpty(location);
            ViewBag.SearchQuery = location ?? "";
            ViewBag.MinHotelPrice = _context.Hotels.Any() ? _context.Hotels.Min(h => h.PricePerNight) : 7000;
            ViewBag.MaxHotelPrice = _context.Hotels.Any() ? _context.Hotels.Max(h => h.PricePerNight) : 50000;
            if (!string.IsNullOrEmpty(location))
            {
                ViewBag.TouristSpots = _context.TouristSpots.Where(t => t.Location.Contains(location)).ToList();
                ViewBag.Hotels = _context.Hotels.Where(h => h.City.Contains(location)).ToList();
                ViewBag.Restaurants = _context.Restaurants.Where(r => r.City.Contains(location)).ToList();
                ViewBag.Resorts = _context.Resorts.Where(r => r.City.Contains(location)).ToList();
            }
            else
            {
                ViewBag.TouristSpots = new List<TouristSpot>();
                ViewBag.Hotels = new List<Hotel>();
                ViewBag.Restaurants = new List<Restaurant>();
                ViewBag.Resorts = new List<Resort>();
            }
            return View();
        }

        public IActionResult AdvancedSearch(string location, string category, decimal? minPrice, decimal? maxPrice, int? minRating, int? qty, string availableOnly)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Account");
            bool? availableBool = null;
            if (availableOnly == "true") availableBool = true;
            if (category == "All") category = null;
            bool hasSearch = !string.IsNullOrEmpty(location) || !string.IsNullOrEmpty(category) || minPrice != null || maxPrice != null || minRating != null || qty != null || availableBool == true;
            ViewBag.HasSearched = hasSearch;
            ViewBag.Location = location;
            ViewBag.Category = category ?? "All";
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.MinRating = minRating;
            ViewBag.Qty = qty;
            ViewBag.AvailableOnly = availableBool;
            if (!hasSearch)
            {
                ViewBag.Hotels = new List<Hotel>();
                ViewBag.Restaurants = new List<Restaurant>();
                ViewBag.Resorts = new List<Resort>();
                ViewBag.TouristSpots = new List<TouristSpot>();
                return View();
            }
            var hotels = _context.Hotels.AsQueryable();
            if (!string.IsNullOrEmpty(location)) hotels = hotels.Where(h => h.City.Contains(location));
            if (minPrice != null) hotels = hotels.Where(h => h.PricePerNight >= minPrice);
            if (maxPrice != null) hotels = hotels.Where(h => h.PricePerNight <= maxPrice);
            if (minRating != null) hotels = hotels.Where(h => h.Rating >= minRating);
            var hotelList = (string.IsNullOrEmpty(category) || category == "Hotel") ? hotels.ToList() : new List<Hotel>();
            if (qty != null && qty > 0) hotelList = hotelList.Take((int)qty).ToList();
            ViewBag.Hotels = hotelList;
            var restaurants = _context.Restaurants.AsQueryable();
            if (!string.IsNullOrEmpty(location)) restaurants = restaurants.Where(r => r.City.Contains(location));
            if (minPrice != null) restaurants = restaurants.Where(r => r.Price >= minPrice);
            if (maxPrice != null) restaurants = restaurants.Where(r => r.Price <= maxPrice);
            if (minRating != null) restaurants = restaurants.Where(r => r.Rating >= minRating);
            if (availableBool == true) restaurants = restaurants.Where(r => r.Availability == true);
            var restList = (string.IsNullOrEmpty(category) || category == "Restaurant") ? restaurants.ToList() : new List<Restaurant>();
            if (qty != null && qty > 0) restList = restList.Take((int)qty).ToList();
            ViewBag.Restaurants = restList;
            var resorts = _context.Resorts.AsQueryable();
            if (!string.IsNullOrEmpty(location)) resorts = resorts.Where(r => r.City.Contains(location));
            if (minPrice != null) resorts = resorts.Where(r => r.Price >= minPrice);
            if (maxPrice != null) resorts = resorts.Where(r => r.Price <= maxPrice);
            if (minRating != null) resorts = resorts.Where(r => r.Rating >= minRating);
            var resortList = (string.IsNullOrEmpty(category) || category == "Resort") ? resorts.ToList() : new List<Resort>();
            if (qty != null && qty > 0) resortList = resortList.Take((int)qty).ToList();
            ViewBag.Resorts = resortList;
            var spots = _context.TouristSpots.AsQueryable();
            if (!string.IsNullOrEmpty(location)) spots = spots.Where(t => t.Location.Contains(location));
            if (minPrice != null) spots = spots.Where(t => t.Price >= minPrice);
            if (maxPrice != null) spots = spots.Where(t => t.Price <= maxPrice);
            if (minRating != null) spots = spots.Where(t => t.Rating >= minRating);
            var spotList = (string.IsNullOrEmpty(category) || category == "TouristSpot") ? spots.ToList() : new List<TouristSpot>();
            if (qty != null && qty > 0) spotList = spotList.Take((int)qty).ToList();
            ViewBag.TouristSpots = spotList;
            return View();
        }
    }
}