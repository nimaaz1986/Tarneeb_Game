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

#region Imports
using System;
using System.Collections.Generic;
#endregion

#region Namespace
namespace Tarneeb.Cards
{

    #region Deck Class
    /// <summary>
    /// A class to manage logic related to deck.
    /// </summary>
    public class Deck
    {
        List<string> cards = new List<string> {
            "AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "0S", "JS", "QS", "KS",
            "AH", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "0H", "JH", "QH", "KH",
            "AD", "2D", "3D", "4D", "5D", "6D","7D", "8D", "9D", "0D", "JD", "QD", "KD",
            "AC", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "0C", "JC", "QC", "KC" };

        /// <summary>
        /// Method to remove the first card.
        /// </summary>
        /// <returns>Cards after removed one.</returns>
        public string Draw()
        {
            string card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            int count = cards.Count;

            //Keep looping as long as card count is greater than 1
            while (count > 1)
            {
                count--;

                //This generates a random number with a given max possible number (number of cards)
                int rand = random.Next(count);

                //This is a generic swapping method, swapping 1 string (card) with another string (card)
                string save = cards[rand];
                cards[rand] = cards[count];
                cards[count] = save;
            }
        }

        /// <summary>
        /// Resets the deck.
        /// </summary>
        public void Reset()
        {
            cards = new List<string>{"AS", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "0S", "JS", "QS", "KS",
            "AH", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "0H", "JH", "QH", "KH",
            "AD", "2D", "3D", "4D", "5D", "6D","7D", "8D", "9D", "0D", "JD", "QD", "KD",
            "AC", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "0C", "JC", "QC", "KC"};
        }
    }
    #endregion
}
#endregion