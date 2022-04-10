using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;
using DRS___Dynamisk_Rangerings_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DRS___Dynamisk_Rangerings_System.Pages.Admin
{
    public class Admin_PanelModel : PageModel
    {

        #region Properties

        public SettingsService SettingsService { get; set; }
        private ParticipantService ParticipantService { get; set; }

        //Settings Objects used to overwrite the ACTUAL settingsobject.
        [BindProperty] public Settings Settings { get; set; }
        public List<Models.Participant> Participants { get; set; }
        public List<SelectListItem> ParticipantList { get; set; }
        [BindProperty] public int SelectedId { get; set; }
        #endregion

        #region Constructor

        public Admin_PanelModel(SettingsService settingsService,ParticipantService participantService)
        {
            ParticipantService = participantService;
            SettingsService = settingsService;
            Settings = new Settings();

        }

        #endregion

        #region Methods

        public void OnGet()
        {
            Participants = ParticipantService.GetParticipants().ToList();
            ParticipantList = new List<SelectListItem>()
            {
                new SelectListItem("Choose..", "0")
            };
            ParticipantList.AddRange(Participants.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList());
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
        public IActionResult OnPost(int Id)
        {
            return Redirect("/Participant/EditParticipant/" + Id);

        }

        #endregion

    }
}
