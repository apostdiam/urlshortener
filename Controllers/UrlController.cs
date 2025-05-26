using Microsoft.AspNetCore.Mvc;

namespace URL_Shortener.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
