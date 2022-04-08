using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.MockData;
using DRS___Dynamisk_Rangerings_System.Models;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    public class ParticipantService : IParticipantService
    {

        #region Enumerations
        public enum SortingOptions
        {
            Name,
            TotalPoints,
            TotalMatches,
            TotalWin,
            Total2nd,
            TotalLoss
        }
        #endregion

        #region Properties

        private List<Participant> Participants { get; set; }
        private DbService<Participant> DbService { get; set; }
        private SettingsService SettingsService { get; set; }

        #endregion

        #region Constructor
        public ParticipantService(DbService<Participant> dbService, SettingsService settingsService)
        {

            DbService = dbService;
            SettingsService = settingsService;
            Participants = dbService.GetObjectsAsync().Result.ToList();
            //Participants = MockData.MockParticipants.GetMockParticipants();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that sorts the Participants by a given parameter.
        /// </summary>
        /// <returns>List of sorted Participants.</returns>
        public IEnumerable<Participant> SortParticipants(SortingOptions sortingOption)
        {

            switch(sortingOption)
            {

                case SortingOptions.Name:           return from participant in Participants orderby participant.Name select participant;
                case SortingOptions.TotalPoints:    return from participant in Participants orderby SettingsService.CalculatePoints(participant) select participant;
                case SortingOptions.TotalMatches:   return from participant in Participants orderby CalculateMatches(participant) select participant;
                case SortingOptions.TotalWin:       return from participant in Participants orderby participant.WonMatches select participant;
                case SortingOptions.Total2nd:       return from participant in Participants orderby participant.SecondMatches select participant;
                case SortingOptions.TotalLoss:      return from participant in Participants orderby participant.LostMatches select participant;

                default: return GetParticipants();

            }

        }

        /// <summary>
        /// Method that returns all participants.
        /// </summary>
        /// <returns>List of participants.</returns>
        public IEnumerable<Participant> GetParticipants()
        {

            return Participants;

        }

        /// <summary>
        /// Method that searches the list of participants, and tries to match an id.
        /// </summary>
        /// <param name="id">ID To search for.</param>
        /// <returns>Null if no participant was found, participant object, if found.</returns>
        public Participant GetParticipant(int id)
        {

            return (from participant in Participants where (participant.Id == id) select participant).SingleOrDefault();

        }

        /// <summary>
        /// Method that adds the given participant object to the list, and also commits it to the database.
        /// </summary>
        /// <param name="participant">Participant object to add.</param>
        public void AddParticipant(Participant participant)
        {

            Participants.Add(participant);
            _ = DbService.AddObjectAsync(participant);

        }

        /// <summary>
        /// Method that removes a given participant object, given by it's id. If no participant was removed, or failed to find, returns null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The removed object, or null.</returns>
        public Participant RemoveParticipant(int id)
        {
            
            Participant participantToRemove = GetParticipant(id);

            if(participantToRemove != null)
            {

                _ = DbService.RemoveObjectAsync(participantToRemove);

            }

            return participantToRemove;

        }

        /// <summary>
        /// Method that updates a given participant, with it's new properties.
        /// </summary>
        /// <param name="participant"></param>
        public void UpdateParticipant(Participant participant)
        {

            Participant participantToUpdate = GetParticipant(participant.Id);

            if(participantToUpdate != null)
            {
                Participants.Remove(participantToUpdate);
            }

            Participants.Add(participant);
            _ = DbService.UpdateObjectAsync(participant);
        }

        public int CalculateMatches(Participant participant)
        {

            int amountOfMatches = 0;
            amountOfMatches += participant.LostMatches;
            amountOfMatches += participant.SecondMatches;
            amountOfMatches += participant.WonMatches;
            return amountOfMatches;

        }

        public List<Tuple<int, int, Models.Participant>> PointPairing(List<Participant> participants)
        {
            List<Tuple<int, int, Models.Participant>> pointPairing = new List<Tuple<int, int, Models.Participant>>();
            foreach (var participant in participants)
            {
                pointPairing.Add(Tuple.Create(SettingsService.CalculatePoints(participant), CalculateMatches(participant), participant));
            }

            return pointPairing;
        }
        #endregion

    }
}
