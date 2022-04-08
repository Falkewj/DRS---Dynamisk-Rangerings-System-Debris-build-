using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;
using DRS___Dynamisk_Rangerings_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DRS___Dynamisk_Rangerings_System.Pages.Admin
{
    public class Admin_PanelModel : PageModel
    {

        #region Properties

        public SettingsService SettingsService { get; set; }
        
        //Settings Objects used to overwrite the ACTUAL settingsobject.
        [BindProperty] public Settings Settings { get; set; }
        #endregion

        #region Constructor

        public Admin_PanelModel(SettingsService settingsService)
        {

            SettingsService = settingsService;
            Settings = new Settings();

        }

        #endregion

        #region Methods

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if(!ModelState.IsValid)
            {
                return Page();
            }

            SettingsService.UpdateSettings(Settings);

            return Page();

        }

        #endregion

    }
}
