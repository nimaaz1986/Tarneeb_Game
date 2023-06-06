#region Header
/*  Group Members:  Shruti Patel
 *                  Bruce Percy Jebaraj
 *                  Eugene Shin
 *                  Ireoluwa Omotoso
 *                  Nima Azadikhah
 *                  Ray Oviasuyi
 *                  Ryan Jordan de Guzman
 
 *  Due Date:       April 21st, 2023
 *  Course Code:    OOP 4200 - 02
 *  Title:          Tarneeb Card Game
 *  Description:    To create a GUI simulation using C# - WPF of a card game named Tarneeb,
 *  GitHub:         
 */
#endregion
#region Namespace 
namespace Tarneeb.Models
{
    #region PlayerDetails Class
    /// <summary>
    /// A model to represent player details.
    /// </summary>
    public class PlayerDetails
    {
        #region Class Attributes
        //Stores the players name
        public string Name { get; set; }

        //Stores the players number
        public int Number { get; set; }

        //Stores the players selected bid
        public int Bid { get; set; }

        //Stores the turn that they bid
        public int BidTurn { get; set; }

        //Stores if the player is first to play a card or not
        public bool IsFirst { get; set; }

        //Stores if the user is the bidder or not
        public bool IsBidder { get; set; }

        //Stores the amount of tricks the player won
        public int TricksWon { get; set; }
        #endregion

        /// <summary>
        /// A constructor for <see cref="PlayerDetails"/>.
        /// </summary>
        /// <param name="name">Player name.</param>
        /// <param name="number">Player number.</param>
        public PlayerDetails(string name, int number)
        {
            Name = name;
            Number = number;
            IsFirst = false;
        }
    }
    #endregion
}
#endregion