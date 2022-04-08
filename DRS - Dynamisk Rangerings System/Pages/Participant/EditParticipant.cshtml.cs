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
    //[Authorize(Roles = "admin")]
    public class EditParticipantModel : PageModel
    {

        [BindProperty]public Models.Participant Participant { get; set; }
        private DbService<Models.Participant> dbService;
        private ParticipantService participantService;

        public EditParticipantModel(DbService<Models.Participant> dbService, ParticipantService participantService)
        {
            this.dbService = dbService;
            this.participantService = participantService;
        }


        public void OnGet(int id)
        {
            Participant = participantService.GetParticipant(id);
        }

        public IActionResult OnPost(int id, string name, int first, int second, int lost)
        {
            Participant.Id = id;
            Participant.Name = name;
            Participant.WonMatches = first;
            Participant.SecondMatches = second;
            Participant.LostMatches = lost;
            participantService.UpdateParticipant(Participant);
            return RedirectToPage("/Standings/Standings");
        }
    }
}
