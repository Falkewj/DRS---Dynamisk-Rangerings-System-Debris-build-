using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRS___Dynamisk_Rangerings_System.Models
{
    public class Settings
    {
        #region Properties
        //Values defaults to 0.
        [Range(0, 9999)] public int PointsForWin { get; set; } = 0;
        [Range(0, 9999)] public int PointsFor2nd { get; set; } = 0;
        [Range(0, 9999)] public int PointsForLoss { get; set; } = 0;
        [Range(2, 16)] public int MaxPlayersPerMatch { get; set; } = 2;
        #endregion

        #region Constructor
        public Settings()
        {

        }
        #endregion

        #region Methods

        #endregion

    }
}
