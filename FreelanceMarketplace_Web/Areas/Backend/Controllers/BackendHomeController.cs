using Microsoft.AspNetCore.Mvc;

namespace FreelanceMarketplace_Web.Area.Backend.Controllers
{
    [Area("Backend")]
    public class BackendHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
