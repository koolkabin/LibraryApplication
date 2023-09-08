using Microsoft.AspNetCore.Identity;

namespace LibraryDAL
{
    public class ApplicationUser : IdentityUser
    {
        public bool Status { get; set; }
    }
}