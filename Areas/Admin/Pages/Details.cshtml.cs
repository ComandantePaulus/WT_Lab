using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WT_Lab.Data;
using WT_Lab.Domain;

namespace WT_Lab.Areas.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly WT_Lab.Data.ApplicationDbContext _context;

        public DetailsModel(WT_Lab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Asset Asset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _context.Asset.FirstOrDefaultAsync(m => m.ID == id);
            if (asset == null)
            {
                return NotFound();
            }
            else
            {
                Asset = asset;
            }
            return Page();
        }
    }
}
