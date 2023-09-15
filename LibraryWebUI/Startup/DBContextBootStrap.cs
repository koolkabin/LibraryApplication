using LibraryDAL;
using Microsoft.AspNetCore.Identity;

namespace LibraryWebUI.Startup
{
    public class DBContextBootStrap
    {
        public UserManager<ApplicationUser> _UserManager { get; set; }
        public RoleManager<IdentityRole> _RoleManage { get; set; }
        public DBContextBootStrap(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _UserManager = userManager;
            _RoleManage = roleManager;
        }
        public async Task SeedData()
        {
            //create default required roles 
            foreach (EnumApplicationRoles item in Enum.GetValues(typeof(EnumApplicationRoles)))
            {
                if (!await _RoleManage.RoleExistsAsync(item.ToString()))
                {
                    await _RoleManage.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString()
                    }); ;
                }
            }


            //create default required superadmin user
            var OldData = _UserManager.FindByEmailAsync("superadmin@gmail.com");
            if (OldData != null)
            {
                //lets create superadmin user
                var appUser = new ApplicationUser()
                {
                    Email = "superadmin@gmail.com",
                    UserName = "superadmin",
                    Status = true,
                    PhoneNumber = "N/A"
                };

                var result = await _UserManager.CreateAsync(appUser);
                if (result.Succeeded)
                {
                    appUser = await _UserManager.FindByNameAsync(appUser.UserName);
                    if (appUser == null) { throw new Exception("Invalid User"); }
                    await _UserManager.AddPasswordAsync(appUser, "123456");
                    //assign roles to created user
                    await _UserManager.AddToRoleAsync(appUser, EnumApplicationRoles.SuperAdmin.ToString());
                    await _UserManager.AddToRoleAsync(appUser, EnumApplicationRoles.GeneralAdmin.ToString());
                }
            }
        }
    }
}