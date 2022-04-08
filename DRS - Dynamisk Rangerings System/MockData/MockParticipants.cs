using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;
using Microsoft.AspNetCore.Identity;

namespace DRS___Dynamisk_Rangerings_System.MockData
{
    public class MockParticipants
    {

        private static List<Participant> participants = new List<Participant>()
        {
            new Participant(1,"Test", 1, 1, 1),
            new Participant(2,"Participant 2", 4, 2, 1)
        };

        public static List<Participant> GetMockParticipants()
        {
            return participants;
        }
    }
}
