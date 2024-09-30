using Microsoft.AspNetCore.Identity;

namespace WT_Lab.Data
{
    public class ApplicationUser:IdentityUser
    {
        public byte[]? Avatar { get; set; }
        public string MimeType { get; set; } = string.Empty;
    }
}
