using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DRS___Dynamisk_Rangerings_System.Pages.Admin
{
    public class AdminLogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
        
            AdminLoginModel.LoggedInAdmin = null;
            AdminLoginModel.Admin = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/index");
        }
    }

}   

