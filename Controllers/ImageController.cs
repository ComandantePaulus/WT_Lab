using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WT_Lab.Data;

namespace WT_Lab.Controllers
{
    public class ImageController(UserManager<ApplicationUser> userManager) : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IActionResult> GetAvatar()
        {
            var email = User.FindFirst(ClaimTypes.Email)!.Value;
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Avatar != null)
                return File(user.Avatar, user.MimeType);
            var imagePath = Path.Combine("Images", "def.png");
            return File(imagePath, "image/png");
        }
    }
}
