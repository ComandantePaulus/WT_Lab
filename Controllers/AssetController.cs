using Microsoft.AspNetCore.Mvc;
using WT_Lab.Entities;
using WT_Lab.Models;
using WT_Lab.Services;

namespace WT_Lab.Controllers
{
    public class AssetController(IAssetService assetService, ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var productResponse =
            await
            assetService.GetProductListAsync(null);
            if (!productResponse.Success)
                return NotFound(productResponse.ErrorMessage);
            return View(productResponse.Data.Items);
        }
        //public async Task<IActionResult> Index(string? category)
        //{
        //    // получить список категорий
        //    var categoriesResponse = await
        //    categoryService.GetCategoryListAsync();
        //    // если список не получен, вернуть код 404
        //    if (!categoriesResponse.Success)
        //        return NotFound(categoriesResponse.ErrorMessage);
        //    // передать список категорий во ViewData
        //    ViewData["categories"] = categoriesResponse.Data;
        //    // передать во ViewData имя текущей категории
        //    var currentCategory = category ==?"Все": categoriesResponse.Data.FirstOrDefault(c =>c.NormalizedName == category)?.Name;
        //    ViewData["currentCategory"] = currentCategory;
        //    var productResponse =
        //    await
        //    productService.GetProductListAsync(category);
        //    if (!productResponse.Success)
        //        ViewData["Error"] = productResponse.ErrorMessage;
        //    return View(productResponse.Data.Items);
        //}
        //public Task<ResponseData<ProductListModel<Asset>>>GetProductListAsync(string? categoryNormalizedName, int pageNo =1)
        //{
        //    // Создать объект результата
        //    var result = new ResponseData<ProductListModel<Asset>>();
        //    // Id категории для фильрации
        //    int? categoryId = null;
        //    // если требуется фильтрация, то найти Id категории
        //    // с заданным categoryNormalizedName
        //    if (categoryNormalizedName != null)
        //        categoryId = _categories
        //        .Find(c =>
        //        c.NormalizedName.Equals(categoryNormalizedName))
        //        ?.Id;
        //    // Выбрать объекты, отфильтрованные по Id категории,
        //    // если этот Id имеется
        //    var data = _dishes
        //    .Where(d => categoryId == ||
        //    d.CategoryId.Equals(categoryId))?
        //    .ToList();
        //    // поместить ранные в объект результата
        //    result.Data = new ProductListModel<Asset>() { Items = data };
        //    // Если список пустой
        //    if (data.Count == 0)
        //    {
        //        result.Success = false;
        //        result.ErrorMessage = "Нет объектов в выбраннной
        //    категории";
        //    }
        //    // Вернуть результат
        //    return Task.FromResult(result);
        //}
    }
}
