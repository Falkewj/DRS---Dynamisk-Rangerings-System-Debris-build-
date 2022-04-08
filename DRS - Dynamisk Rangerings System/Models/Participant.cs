using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRS___Dynamisk_Rangerings_System.Models
{
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WonMatches { get; set; }
        public int SecondMatches { get; set; }
        public int  LostMatches { get; set; }

        #region Constructor
        public Participant(int id, string name, int wonMatches, int secondMatches, int lostMatches)
        {
            Id = id;
            Name = name;
            WonMatches = wonMatches;
            SecondMatches = secondMatches;
            LostMatches = lostMatches;
        }

        public Participant()
        {
            
        }
        #endregion
    }
}
