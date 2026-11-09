using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KarnelTravelGuide.Data;
using KarnelTravelGuide.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelGuide.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context) { _context = context; }

        [HttpGet] public IActionResult login() { return View(); }
        [HttpPost] public IActionResult login(string Email, string Password) { if (Email == "admin@karnel.com" && Password == "admin123") { HttpContext.Session.SetString("AdminLoggedIn", "true"); return RedirectToAction("Dashboard"); } ViewBag.Error = "Invalid Email or Password"; return View(); }
        public IActionResult Logout() { HttpContext.Session.Clear(); return RedirectToAction("login"); }

        public IActionResult Dashboard() { return View(); }
        public IActionResult Hotels() { return View(_context.Hotels.ToList()); }
        public IActionResult Users() { return View(_context.Users.ToList()); }
        public IActionResult Resorts() { return View(_context.Resorts.ToList()); }
        public IActionResult Restaurants() { return View(_context.Restaurants.ToList()); }
        public IActionResult TouristSpots() { return View(_context.TouristSpots.ToList()); }
        public IActionResult TravelInfo() { return View(_context.TravelInfos.ToList()); }
        public IActionResult Orders() { return View(_context.Orders.ToList()); }
        public IActionResult Feedback() { return View(); }
        public IActionResult Messages() { return View(); }
        public IActionResult Settings() { return View(); }

        [HttpPost][ValidateAntiForgeryToken] public IActionResult SaveProfile(string AdminName, string Email) { TempData["SuccessMessage"] = "Profile saved!"; return RedirectToAction("Settings"); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult UpdateSystem(string WebsiteName, string ContactEmail, string Currency) { TempData["SuccessMessage"] = "System updated!"; return RedirectToAction("Settings"); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult ChangePassword(string CurrentPassword, string NewPassword, string ConfirmPassword) { if (NewPassword != ConfirmPassword) { TempData["ErrorMessage"] = "No match!"; return RedirectToAction("Settings"); } TempData["SuccessMessage"] = "Password changed!"; return RedirectToAction("Settings"); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult ClearCache() { TempData["SuccessMessage"] = "Cache cleared!"; return RedirectToAction("Settings"); }

        [HttpGet] public IActionResult AddHotel() => View();
        [HttpPost][ValidateAntiForgeryToken] public async Task<IActionResult> AddHotel(Hotel model, IFormFile? ImageFile) { if (ImageFile != null) model.ImageUrl = await SaveImage(ImageFile); _context.Hotels.Add(model); _context.SaveChanges(); return RedirectToAction("Hotels"); }

        [HttpGet] public IActionResult AddResort() => View();
        [HttpPost][ValidateAntiForgeryToken] public async Task<IActionResult> AddResort(Resort model, IFormFile? ImageFile) { if (ImageFile != null) model.ImageUrl = await SaveImage(ImageFile); _context.Resorts.Add(model); _context.SaveChanges(); return RedirectToAction("Resorts"); }

        [HttpGet] public IActionResult AddRestaurant() => View();
        [HttpPost][ValidateAntiForgeryToken] public IActionResult AddRestaurant(Restaurant model) { _context.Restaurants.Add(model); _context.SaveChanges(); return RedirectToAction("Restaurants"); }

        [HttpGet] public IActionResult AddTouristSpot() => View();
        [HttpPost][ValidateAntiForgeryToken] public IActionResult AddTouristSpot(TouristSpot model) { _context.TouristSpots.Add(model); _context.SaveChanges(); return RedirectToAction("TouristSpots"); }

        [HttpGet] public IActionResult AddTravelInfo() => View();
        [HttpPost][ValidateAntiForgeryToken] public IActionResult AddTravelInfo(TravelInfo model) { _context.TravelInfos.Add(model); _context.SaveChanges(); return RedirectToAction("TravelInfo"); }

        [HttpGet] public IActionResult AddOrder() => View();
        [HttpPost][ValidateAntiForgeryToken] public IActionResult AddOrder(Order model) { model.CreatedAt = DateTime.Now; model.Status = "Pending"; _context.Orders.Add(model); _context.SaveChanges(); return RedirectToAction("Orders"); }

        // --- FIXED AddUser ---
        [HttpGet] public IActionResult AddUser() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(User model)
        {
            model.JoinedDate = DateTime.Now;
            if (string.IsNullOrEmpty(model.Status)) model.Status = "Active";
            if (string.IsNullOrEmpty(model.Role)) model.Role = "User";
            _context.Users.Add(model);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "User added successfully!";
            return RedirectToAction("Users");
        }

        // --- ADDED Missing Methods ---
        public IActionResult ToggleUserStatus(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Status = user.Status == "Active" ? "Blocked" : "Active";
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"User {user.Status} successfully!";
            }
            return RedirectToAction("Users");
        }

        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "User deleted!";
            }
            return RedirectToAction("Users");
        }

        [HttpGet] public IActionResult EditTravelInfo(int id) { var data = _context.TravelInfos.FirstOrDefault(x => x.Id == id); if (data == null) return NotFound(); return View(data); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult EditTravelInfo(TravelInfo model) { var old = _context.TravelInfos.FirstOrDefault(x => x.Id == model.Id); if (old == null) return NotFound(); old.FromCity = model.FromCity; old.ToCity = model.ToCity; old.TransportType = model.TransportType; old.Price = model.Price; _context.SaveChanges(); return RedirectToAction("TravelInfo"); }
        public IActionResult DeleteTravelInfo(int id) { var data = _context.TravelInfos.Find(id); if (data != null) { _context.TravelInfos.Remove(data); _context.SaveChanges(); } return RedirectToAction("TravelInfo"); }
        public IActionResult UpdateTravelInfo(int id) { return RedirectToAction("EditTravelInfo", new { id }); }

        [HttpGet] public IActionResult EditHotel(int id) { var hotel = _context.Hotels.FirstOrDefault(x => x.Id == id); if (hotel == null) return NotFound(); return View(hotel); }
        [HttpPost][ValidateAntiForgeryToken] public async Task<IActionResult> EditHotel(Hotel model, IFormFile? ImageFile) { var old = _context.Hotels.FirstOrDefault(x => x.Id == model.Id); if (old == null) return NotFound(); old.Name = model.Name; old.City = model.City; old.PricePerNight = model.PricePerNight; old.Rating = model.Rating; old.Availability = model.Availability; if (ImageFile != null && ImageFile.Length > 0) { old.ImageUrl = await SaveImage(ImageFile); } _context.SaveChanges(); return RedirectToAction("Hotels"); }
        public IActionResult DeleteHotel(int id) { var hotel = _context.Hotels.Find(id); if (hotel != null) { _context.Hotels.Remove(hotel); _context.SaveChanges(); } return RedirectToAction("Hotels"); }

        [HttpGet] public IActionResult EditResort(int id) { var resort = _context.Resorts.FirstOrDefault(x => x.Id == id); if (resort == null) return NotFound(); return View(resort); }
        [HttpPost][ValidateAntiForgeryToken] public async Task<IActionResult> EditResort(Resort model, IFormFile? ImageFile) { var old = _context.Resorts.FirstOrDefault(x => x.Id == model.Id); if (old == null) return NotFound(); old.Name = model.Name; old.City = model.City; old.Price = model.Price; old.Rating = model.Rating; old.Availability = model.Availability; if (ImageFile != null && ImageFile.Length > 0) { old.ImageUrl = await SaveImage(ImageFile); } _context.SaveChanges(); return RedirectToAction("Resorts"); }
        public IActionResult DeleteResort(int id) { var resort = _context.Resorts.Find(id); if (resort != null) { _context.Resorts.Remove(resort); _context.SaveChanges(); } return RedirectToAction("Resorts"); }

        [HttpGet] public IActionResult EditRestaurant(int id) { var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id); if (restaurant == null) return NotFound(); return View(restaurant); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult EditRestaurant(Restaurant model) { var old = _context.Restaurants.FirstOrDefault(x => x.Id == model.Id); if (old == null) return NotFound(); _context.Entry(old).CurrentValues.SetValues(model); _context.SaveChanges(); return RedirectToAction("Restaurants"); }
        public IActionResult DeleteRestaurant(int id) { var restaurant = _context.Restaurants.Find(id); if (restaurant != null) { _context.Restaurants.Remove(restaurant); _context.SaveChanges(); } return RedirectToAction("Restaurants"); }

        [HttpGet] public IActionResult EditTouristSpot(int id) { var spot = _context.TouristSpots.FirstOrDefault(x => x.Id == id); if (spot == null) return NotFound(); return View(spot); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult EditTouristSpot(TouristSpot model) { var old = _context.TouristSpots.FirstOrDefault(x => x.Id == model.Id); if (old == null) return NotFound(); _context.Entry(old).CurrentValues.SetValues(model); _context.SaveChanges(); return RedirectToAction("TouristSpots"); }
        public IActionResult DeleteTouristSpot(int id) { var spot = _context.TouristSpots.Find(id); if (spot != null) { _context.TouristSpots.Remove(spot); _context.SaveChanges(); } return RedirectToAction("TouristSpots"); }

        public IActionResult ViewOrder(int id) { return RedirectToAction("OrderDetails", new { id = id }); }
        public IActionResult OrderDetails(int id) { var order = _context.Orders.FirstOrDefault(x => x.Id == id); if (order == null) return NotFound(); return View(order); }
        public IActionResult ConfirmOrder(int id) { var order = _context.Orders.FirstOrDefault(x => x.Id == id); if (order != null) { order.Status = "Confirmed"; _context.SaveChanges(); } return RedirectToAction("Orders"); }
        public IActionResult EditOrder(int id) { var order = _context.Orders.FirstOrDefault(x => x.Id == id); if (order == null) return NotFound(); return View(order); }
        [HttpPost][ValidateAntiForgeryToken] public IActionResult EditOrder(Order model) { var old = _context.Orders.FirstOrDefault(x => x.Id == model.Id); if (old != null) { old.FullName = model.FullName; old.Email = model.Email; old.Phone = model.Phone; old.OrderType = model.OrderType; old.Location = model.Location; old.Details = model.Details; _context.SaveChanges(); } return RedirectToAction("Orders"); }
        public IActionResult DeleteOrder(int id) { var d = _context.Orders.Find(id); if (d != null) { _context.Orders.Remove(d); _context.SaveChanges(); } return RedirectToAction("Orders"); }

        private async Task<string> SaveImage(IFormFile file) { var name = Guid.NewGuid() + Path.GetExtension(file.FileName); var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"); Directory.CreateDirectory(directory); var path = Path.Combine(directory, name); using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); } return "/images/" + name; }
    }
}