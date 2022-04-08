using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DRS___Dynamisk_Rangerings_System.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class CreateUserModel : PageModel
    {
        private AdminService _adminService;
        private PasswordHasher<string> passwordHasher;

        [BindProperty]public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]public string Password { get; set; }

        public CreateUserModel(AdminService adminService)
        {
            _adminService = adminService;
            passwordHasher = new PasswordHasher<string>();
        }

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _adminService.AddAdmin(new Models.Admin(UserName, passwordHasher.HashPassword(null, Password)));
        //    return RedirectToPage("/Admin/AdminPanel");
        //}
    }
}
