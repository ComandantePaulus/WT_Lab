using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WT_Lab.Data;
using WT_Lab.Domain;
using WT_Lab.Services;

namespace WT_Lab.Areas.Admin
{

    public class CreateModel(ICategoryService categoryService, IAssetService assetService) : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            var categoryListData = await categoryService.GetCategoryListAsync();
            ViewData["CategoryId"] = new SelectList(categoryListData.Data, "ID","Name");
            return Page();
        }
        [BindProperty]
        public Asset Asset { get; set; } = default!;
        [BindProperty]
        public IFormFile? Photo { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //var categoryListData = await categoryService.GetCategoryListAsync();
            //Asset.Category = categoryListData.Data[0];


            ////////Вот здесь все ломается: не валидируется категория при выборе///////
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await assetService.CreateAssetAsync(Asset, Photo);
            return RedirectToPage("./Index");
        }
    }
}
