using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using KarnelTravelGuide.Models;
using KarnelTravelGuide.Data;
using System.Linq;

namespace KarnelTravelGuide.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            var check = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (check != null)
            {
                ViewBag.Error = "Email already exists";
                return View();
            }
            user.Role = "User";
            user.Status = "Active";
            user.JoinedDate = System.DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["Success"] = "Registered! Please Login";
            return RedirectToAction("Login");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            if (Email == "admin@karnel.com" && Password == "admin123")
            {
                HttpContext.Session.SetString("AdminLoggedIn", "true");
                HttpContext.Session.SetString("UserName", "Admin");
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Dashboard", "Admin");
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("Role", "User");
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid Email or Password";
            return View();
        }

        // ===== FORGET PASSWORD =====
        public IActionResult ForgotPassword() => View();

        [HttpPost]
        public IActionResult ForgotPassword(string Email, string NewPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null)
            {
                ViewBag.Error = "Email not found!";
                return View();
            }
            user.Password = NewPassword;
            _context.Users.Update(user);
            _context.SaveChanges();
            TempData["Success"] = "Password changed! Please login with new password.";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}