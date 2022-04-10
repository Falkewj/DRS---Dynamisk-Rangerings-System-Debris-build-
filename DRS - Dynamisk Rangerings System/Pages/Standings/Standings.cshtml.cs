using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DRS___Dynamisk_Rangerings_System.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DRS___Dynamisk_Rangerings_System.Pages.Standings
{
    public class StandingsModel : PageModel
    {

        #region Properties
        public List<Models.Participant> Participants { get; set; }
        public bool IsAdmin { get; set; }
        private ParticipantService ParticipantService { get; set; }
        private SettingsService SettingsService { get; set; }
        private ParticipantService participantService;
        private SettingsService settingsService;
        public List<Tuple<int,int, Models.Participant>> PointPairing { get; set; }

        [BindProperty] public int NumberOfParticipants { get; set; }

        [BindProperty] public List<int> SelectedPartipantIDs { get; set; }
        public List<SelectListItem> ParticipantListItems { get; set; }
        #endregion

        public StandingsModel(SettingsService settingsService, ParticipantService participantService)
        {

            SettingsService = settingsService;
            ParticipantService = participantService;

            Participants = ParticipantService.GetParticipants().ToList();

            ParticipantListItems = new List<SelectListItem>() { new SelectListItem("Vælg en deltager..", "0") };
            ParticipantListItems.AddRange(Participants.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList());

            this.settingsService = settingsService;
            this.participantService = participantService;
            NumberOfParticipants = settingsService.GetMaxParticipants();
        }

        public IActionResult OnPost()
        {

            for(int i = 0; i < SelectedPartipantIDs.Count; i++)
            {

                Models.Participant participantToUpdate = ParticipantService.GetParticipant(SelectedPartipantIDs[i]);
                
                if(participantToUpdate != null)
                {
                    
                    if (i == 0) participantToUpdate.WonMatches += 1;
                    else if (i == 1) participantToUpdate.SecondMatches += 1;
                    else participantToUpdate.LostMatches += 1;

                    ParticipantService.UpdateParticipant(participantToUpdate);

                }

            }

            return OnGet();

        }

        public IActionResult OnGet()
        {
            Participants = participantService.GetParticipants().ToList();
            PointPairing = participantService.PointPairing(Participants);
            return Page();
        }

        #region OnGet Sorts
        public IActionResult OnGetSortByName()
        {
            Participants = ParticipantService.SortParticipants(ParticipantService.SortingOptions.Name).ToList();
           Participants = participantService.SortParticipants(ParticipantService.SortingOptions.Name).ToList();
           PointPairing = participantService.PointPairing(Participants);
            return Page();
        }
        public IActionResult OnGetSortByPoints()
        {
            Participants = ParticipantService.SortParticipants(ParticipantService.SortingOptions.TotalPoints).ToList();
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalPoints).ToList();
            PointPairing = participantService.PointPairing(Participants);
            return Page();
        }
        public IActionResult OnGetSortByPointsDescending()
        {
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalPoints).ToList();
            PointPairing = participantService.PointPairing(Participants);
            PointPairing.Reverse();
            return Page();
        }
        public IActionResult OnGetSortByWins()
        {
           Participants = ParticipantService.SortParticipants(ParticipantService.SortingOptions.TotalWin).ToList();
           Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalWin).ToList();
           PointPairing = participantService.PointPairing(Participants);
           return Page();
        }
        public IActionResult OnGetSortByWinsDescending()
        {
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalWin).ToList();
            PointPairing = participantService.PointPairing(Participants);
            PointPairing.Reverse();
            return Page();
        }
        public IActionResult OnGetSortByMatches()
        {
            Participants = ParticipantService.SortParticipants(ParticipantService.SortingOptions.TotalMatches).ToList(); 
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalMatches).ToList();
            PointPairing = participantService.PointPairing(Participants);
            return Page();
        }
        public IActionResult OnGetSortByMatchesDescending()
        {
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalMatches).ToList();
            PointPairing = participantService.PointPairing(Participants);
            PointPairing.Reverse();
            return Page();
        }
        public IActionResult OnGetSortBySeconds()
        {
            Participants = ParticipantService.SortParticipants(ParticipantService.SortingOptions.Total2nd).ToList(); 
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.Total2nd).ToList();
            PointPairing = participantService.PointPairing(Participants);
            return Page();
        }
        public IActionResult OnGetSortBySecondsDescending()
        {
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.Total2nd).ToList();
            PointPairing = participantService.PointPairing(Participants);
            PointPairing.Reverse();
            return Page();
        }
        public IActionResult OnGetSortByLoss()
        {
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalLoss).ToList();
            PointPairing = participantService.PointPairing(Participants);
            return Page();
        }
        public IActionResult OnGetSortByLossDescending()
        {
            Participants = participantService.SortParticipants(ParticipantService.SortingOptions.TotalLoss).ToList();
            PointPairing = participantService.PointPairing(Participants);
            PointPairing.Reverse();
            return Page();
        }
        #endregion

    }
}
