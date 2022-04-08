using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Pages.Admin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DRS___Dynamisk_Rangerings_System.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if(AdminLoginModel.LoggedInAdmin == null)
            {
                    HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
