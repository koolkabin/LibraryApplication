using Microsoft.AspNetCore.Identity;

namespace LibraryDAL
{
    public enum EnumApplicationRoles
    {
        SuperAdmin = 1,
        GeneralAdmin = 2,
        Operator,
        Student
    }
    public class ApplicationUser : IdentityUser
    {
        public bool Status { get; set; }
    }
}