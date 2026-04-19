using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInformation
{
    public class Player
    {
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ScoreTot { get; set; } = 0;
        public int ScoreRound { get; set; } = 0;
        public int PlayerID { get; set; }
        public Player(string pseudo, string firstName, string lastName, int playerID)
        {
            Pseudo = pseudo;
            FirstName = firstName;
            LastName = lastName;
            PlayerID = playerID;
        }
        public Player(string pseudo)
        {
            Pseudo = pseudo;
        }
    }
}
