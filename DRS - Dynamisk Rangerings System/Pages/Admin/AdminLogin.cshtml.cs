using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DRS___Dynamisk_Rangerings_System.Pages.Admin
{
    public class AdminLoginModel : PageModel
    {
        public static Models.Admin LoggedInAdmin { get; set; } = null;

        private AdminService _adminService;
        [BindProperty] public string UserName { get; set; }
        public string Message { get; set; }
        //Both the folder I'm working in and the class I'm working with is named Admin so declaring the var as Models.Admin is necessary.
        public static Models.Admin Admin { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public AdminLoginModel(AdminService adminService)
        {
            _adminService = adminService;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            IEnumerable<Models.Admin> admins = _adminService.GetAdmins();
            var passwordHasher = new PasswordHasher<string>();
            foreach (Models.Admin admin in admins)
            {

                if (UserName == admin.UserName && passwordHasher.VerifyHashedPassword(null, admin.Password, Password) == PasswordVerificationResult.Success)
                {

                    Admin = admin;

                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName), new Claim(ClaimTypes.Role, "admin") };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Standings/Standings");

                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}