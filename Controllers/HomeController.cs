using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WT_Lab.Models;
using WT_Lab.ViewModels;

namespace WT_Lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["LabTitle"] = "Лабораторная работа 1";
            var items = new List<ListDemo>
    {
        new ListDemo { Id = 1, Name = "Элемент 1" },
        new ListDemo { Id = 2, Name = "Элемент 2" },
        new ListDemo { Id = 3, Name = "Элемент 3" }
    };

            var selectList = new SelectList(items, "Id", "Name");

            var model = new ListDemoViewModel
            {
                Items = selectList
            };
            return View(model);
        }
    }
}
