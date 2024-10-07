using Microsoft.AspNetCore.Mvc;
using WT_Lab.Domain;
using WT_Lab.Models;
using WT_Lab.Services;

namespace WT_Lab.Controllers
{
    public class AssetController(IAssetService assetService, ICategoryService categoryService) : Controller
    {
        //public async Task<IActionResult> Index()
        //{
        //    var productResponse =
        //    await
        //    assetService.GetProductListAsync(null);
        //    if (!productResponse.Success)
        //        return NotFound(productResponse.ErrorMessage);
        //    return View(productResponse.Data.Items);
        //}
        public async Task<IActionResult> Index(string? category)
        {
            // получить список категорий
            var categoriesResponse = await
            categoryService.GetCategoryListAsync();
            // если список не получен, вернуть код 404
            if (!categoriesResponse.Success)
                return NotFound(categoriesResponse.ErrorMessage);
            // передать список категорий во ViewData
            ViewData["categories"] = categoriesResponse.Data;
            // передать во ViewData имя текущей категории
            var currentCategory = category =="Все" ? "Все" : categoriesResponse.Data.FirstOrDefault(c => c.NormalizedName == category)?.Name;
            if (currentCategory == null) currentCategory = "Все";
            ViewData["currentCategory"] = currentCategory;
            var productResponse =
            await
            assetService.GetProductListAsync(category);
            if (!productResponse.Success)
                ViewData["Error"] = productResponse.ErrorMessage;
            return View(productResponse.Data.Items);
        }
    }
}
