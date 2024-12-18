using Microsoft.AspNetCore.Mvc;
using WebApplication1_HW_13_12_2024.Models;

namespace WebApplication1_HW_13_12_2024.Controllers
{
    public class BlogController : Controller
    {
        private static readonly List<News> NewsList = new List<News>
    {
        new News { Id = 1, Title = "Первая новость", Content = "Контент 1", PublishedDate = DateTime.Now.AddDays(-1) },
        new News { Id = 2, Title = "Вторая новость", Content = "Контент 2", PublishedDate = DateTime.Now.AddDays(-2) },
        new News { Id = 3, Title = "Третья новость", Content = "Контент 3", PublishedDate = DateTime.Now.AddDays(-3) }
    };

        public IActionResult Index()
        {
            var theme = Request.Cookies["Theme"] ?? "light";
            ViewBag.Theme = theme;

            return View(NewsList);
        }

        public IActionResult Settings()
        {
            ViewBag.Theme = Request.Cookies["Theme"] ?? "light";
            return View();
        }

        [HttpPost]
        public IActionResult SaveSettings(string theme)
        {
            Response.Cookies.Append("Theme", theme, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            });

            return RedirectToAction("Index");
        }
    }
}

