using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    interface ISettingsService
    {
        public int CalculatePoints(Participant participant);

        public int GetMaxParticipants();
    }
}
