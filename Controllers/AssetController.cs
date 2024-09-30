using Microsoft.AspNetCore.Mvc;

namespace WT_Lab.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
