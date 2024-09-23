using Microsoft.AspNetCore.Mvc;

namespace WT_Lab.Components
{
    public class CartViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}
