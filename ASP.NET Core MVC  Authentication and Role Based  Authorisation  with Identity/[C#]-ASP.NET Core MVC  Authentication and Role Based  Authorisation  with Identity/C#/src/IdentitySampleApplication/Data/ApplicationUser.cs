using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentitySampleApplication.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
