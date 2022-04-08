using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    public class SettingsService : ISettingsService
    {

        #region Enumerations
        public enum SettingsTypes
        {
            MaxPlayers,
            WonPoints,
            SecondPoints,
            LossPoints
        }
        #endregion

        #region Properties
        private Settings Settings { get; set; }
        private JsonFileService<Settings> JsonFileService { get; set; }
        #endregion

        #region Constructor
        public SettingsService(JsonFileService<Settings> jsonFileService)
        {

            JsonFileService = jsonFileService;

            #region Initial Setup
            //Uncomment the line below, to create the initial settings file.
            //CreateSettingsFile();
            #endregion

            Settings = JsonFileService.GetJsonObjects().ToList()[0];

        }


        #endregion

        #region Methods
        /// <summary>
        /// Method that returns the Settings object.
        /// </summary>
        /// <returns></returns>
        public Settings GetSettings()
        {
            return Settings;
        }

        /// <summary>
        /// Method that updates the Settings object.
        /// </summary>
        public void UpdateSettings(Settings settings)
        {

            Settings = settings;
            JsonFileService.SaveJsonObjects(new List<Settings>() { Settings });

        }

        /// <summary>
        /// Method that calculates the points for a given participant.
        /// </summary>
        /// <param name="participant"></param>
        /// <returns></returns>
        public int CalculatePoints(Participant participant)
        {
            int totalpoints = 0;
            totalpoints += participant.WonMatches * Settings.PointsForWin;
            totalpoints += participant.SecondMatches * Settings.PointsFor2nd;
            totalpoints += participant.LostMatches * Settings.PointsForLoss;
            return totalpoints;
        } 

        /// <summary>
        /// Method that returns the maximum number of participants from the settings file.
        /// </summary>
        /// <returns>int indicating max players.</returns>
        public int GetMaxParticipants()
        {
            return Settings.MaxPlayersPerMatch;
        }

        /// <summary>
        /// Method that returns the number given for a given position.
        /// </summary>
        /// <returns></returns>
        public int GetPoints(SettingsTypes pointTypes)
        {
            
            switch(pointTypes)
            {

                case SettingsTypes.WonPoints: return Settings.PointsForWin;
                case SettingsTypes.SecondPoints: return Settings.PointsFor2nd;
                case SettingsTypes.LossPoints: return Settings.PointsForLoss;

                default: return 0;

            }

        }

        /// <summary>
        /// Method that creates the initial settings file.
        /// </summary>
        private void CreateSettingsFile()
        {

            if (Settings == null) Settings = new Settings();
            JsonFileService.SaveJsonObjects(new List<Settings>() { Settings });

        }
        #endregion

    }
}
