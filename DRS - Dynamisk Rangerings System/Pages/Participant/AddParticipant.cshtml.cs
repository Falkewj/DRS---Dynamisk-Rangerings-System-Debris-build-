using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DRS___Dynamisk_Rangerings_System.Pages.Participant
{
    public class AddParticipantModel : PageModel
    {
        [BindProperty]
        public Models.Participant Participant { get; set; }
        private ParticipantService ParticipantService { get; set; }

        public AddParticipantModel(ParticipantService participantService)
        {
            ParticipantService = participantService;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ParticipantService.AddParticipant(Participant);
            return RedirectToPage("/Standings/Standings");
        }

    }
}
