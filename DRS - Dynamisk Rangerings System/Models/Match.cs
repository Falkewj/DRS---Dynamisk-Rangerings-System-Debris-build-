using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Services;

namespace DRS___Dynamisk_Rangerings_System.Models
{
    public class Match
    {
        public List<Participant> Participants { get; set; }
        private SettingsService SettingsService { get; set; }
        public int Id { get; set; }
        public List<Int32> Matches { get; set; }

        public void CalculateMatch()
        {

        }

        public void GetMatchResult()
        {

        }


    }
}
