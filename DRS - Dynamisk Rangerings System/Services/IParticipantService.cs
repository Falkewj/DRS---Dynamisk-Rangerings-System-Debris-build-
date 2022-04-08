using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    interface IParticipantService
    {
        public IEnumerable<Participant> SortParticipants(ParticipantService.SortingOptions so);

        public IEnumerable<Participant> GetParticipants();

        public Participant GetParticipant(int id);

        public void AddParticipant(Participant participant);

        public Participant RemoveParticipant(int id);
        public void UpdateParticipant(Participant participant);

    }
}
