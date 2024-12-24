using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WT_Lab.Data;
using WT_Lab.Domain;
using WT_Lab.Services;

namespace WT_Lab.Areas.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IAssetService _assetService;
        public IndexModel(IAssetService assetService)
        {
            //_context = context;
            _assetService = assetService;
        }
        public List<Asset> Asset { get; set; } = default!;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public async Task OnGetAsync(int? pageNo = 1)
        {
            var response = await _assetService.GetProductListAsync(null, pageNo.Value);
            if (response.Success)
            {
                Asset = response.Data.Items;
                CurrentPage = response.Data.CurrentPage;
                TotalPages = response.Data.TotalPages;
            }
        }

        //private readonly WT_Lab.Data.ApplicationDbContext _context;

        //public IndexModel(WT_Lab.Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public IList<Asset> Asset { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    Asset = await _context.Asset.ToListAsync();
        //}
    }
}
