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
using System.Linq;
using Tarneeb.Cards;
#endregion

#region Namespace
namespace Tarneeb
{
    #region Hand Class
    public class Hand
    {
        /// <summary>
        /// Maximum number of Cards
        /// </summary>
        private const int totalCards = 13;

        /// <summary>
        /// List of Card codes
        /// </summary>
        private List<string> codes = new List<string>();

        /// <summary>
        /// List of Cards
        /// </summary>
        private List<Card> theHand = new List<Card>();

        /// <summary>
        /// Returns theHand.
        /// </summary>
        /// <returns>List<Card></returns>
        public List<Card> GetHand()
        {
            return theHand;
        }

        /// <summary>
        /// Parameterized Constructor
        /// Takes a Deck object and uses the Draw method to take card codes to fill it's own card code list.
        /// </summary>
        /// <param name="deck"></param>
        public Hand(Deck deck)
        {
            for (int i = 1; i <= totalCards; i++)
            {
                string code = deck.Draw();
                codes.Add(code);
            }

            CreateHand();
        }

        #region Methods
        /// <summary>
        /// Designed to remove the first card in the card list (theHand) that has been played (isPlayed value is true).
        /// </summary>
        public void UpdateTheHand()
        {
            for (int i = 0; i < theHand.Count; i++)
            {
                if (theHand[i].IsPlayed)
                {
                    theHand.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Orders theHand by suit.
        /// </summary>
        public void OrderBySuit()
        {
            theHand = theHand.OrderBy(a => a.TheSuit).ThenByDescending(a => a.TheRank).ToList();
        }

        /// <summary>
        /// Used to find the full name of the suit of the card that has been played (this is done by checking
        /// each card's isPlayed value and code).
        /// </summary>
        /// <returns>string</returns>
        public string FindPlayedSuit()
        {
            string playedSuit = "";

            for (int i = 0; i < theHand.Count; i++)
            {
                if (theHand[i].IsPlayed)
                {
                    if (theHand[i].Code.Contains("S"))
                    {
                        playedSuit = "Spades";
                    }
                    else if (theHand[i].Code.Contains("H"))
                    {
                        playedSuit = "Hearts";
                    }
                    else if (theHand[i].Code.Contains("D"))
                    {
                        playedSuit = "Diamonds";
                    }
                    else if (theHand[i].Code.Contains("C"))
                    {
                        playedSuit = "Clubs";
                    }
                }
            }

            return playedSuit;
        }

        /// <summary>
        /// Used to find the index of the first playable card in the hand (for AI).
        /// </summary>
        /// <param name="suitLed"></param>
        /// <param name="trump"></param>
        /// <returns>Card</returns>
        public Card PlayFirstPlayable(string suitLed, string trump)
        {
            Card firstPlayable = null;

            foreach (Card card in theHand)
            {
                if (card.IsPlayable == true)
                {
                    card.IsPlayed = true;
                    card.IsPlayable = false;
                    firstPlayable = card;
                    break;
                }
            }

            //Increase rank of the Card if it matches suit
            if (firstPlayable.TheSuit == suitLed)
            {
                firstPlayable.TheRank += 50;
            }

            //Increase rank of the Card if it matches trump
            if (firstPlayable.TheSuit == trump)
            {
                firstPlayable.TheRank += 100;
            }

            
            return firstPlayable;
        }

        /// <summary>
        /// Randomly selects a Card from theHand, sets it's isPlayed to true and isPlayable value to false,
        /// and returns the Card. Used by AI.
        /// </summary>
        /// <returns>Card</returns>
        public Card PlayRandomCard()
        {
            Random card = new Random();
            int rand = card.Next(theHand.Count);

            theHand[rand].IsPlayed = true;
            theHand[rand].IsPlayable = false;

            return theHand[rand];
        }

        /// <summary>
        /// Takes the suit led, trump, a list of current played cards, and selected difficulty as parameters
        /// and selects a logical card to play based on those values. Used by AI.
        /// </summary>
        /// <param name="suitLed"></param>
        /// <param name="trump"></param>
        /// <param name="playedCards"></param>
        /// <param name="difficulty"></param>
        /// <returns>Card</returns>
        public Card PlayLogicalCard(string suitLed, string trump, List<Card> playedCards, int difficulty)
        {
            Card logicalCard = null;
            Card teammateCard = null;
            List<Card> ranked = new List<Card> { };
            int teammate = 0;

            foreach (Card card in theHand)
            {
                if (card.IsPlayable == true)
                {
                    if (suitLed == card.TheSuit)
                    {
                        card.TheRank += 50;
                    }

                    if (trump == card.TheSuit)
                    {
                        card.TheRank += 100;
                    }

                    ranked.Add(card);
                }
            }

            //Initially order the AIs Hand by rank from highest to lowest
            ranked = ranked.OrderByDescending(a => a.TheRank).ToList();

            if (playedCards.Count != 0)
            {
                playedCards = playedCards.OrderByDescending(a => a.TheRank).ToList();

                if (difficulty == 3)
                {
                    //Finding the AI players number
                    int owner = theHand[0].OwnedBy;

                    //If AI player is 2, teammate must be 4 (AI)
                    if (owner == 2)
                    {
                        teammate = 4;
                    }
                    //If AI player is 3, teammate must be 1 (user)
                    else if (owner == 3)
                    {
                        teammate = 1;
                    }
                    //If AI player is 4, teammate must be 2 (AI)
                    else if (owner == 4)
                    {
                        teammate = 2;
                    }

                    //Finding the Card played by the AIs teammate
                    foreach (Card card in playedCards)
                    {
                        if (card.OwnedBy == teammate)
                        {
                            teammateCard = card;
                        }
                    }
                }

                if (playedCards[0].TheRank > ranked[0].TheRank)
                {
                    ranked = ranked.OrderBy(a => a.TheRank).ToList();
                }
                else if (playedCards[0].TheRank < ranked[0].TheRank && playedCards[0].OwnedBy == teammate)
                {
                    ranked = ranked.OrderBy(a => a.TheRank).ToList();
                }
            }

            logicalCard = ranked[0];

            logicalCard.IsPlayed = true;
            logicalCard.IsPlayable = false;

            return logicalCard;
        }

        /// <summary>
        /// Finds the the played Card in theHand using its isPlayed value.
        /// </summary>
        /// <returns>Card</returns>
        public Card FindPlayedCard()
        {
            Card played = null;

            foreach (Card card in theHand)
            {
                if (card.IsPlayed == true)
                {
                    played = card;
                    break;
                }
            }

            return played;
        }

        /// <summary>
        /// Resets the ranks of all Cards in theHand.
        /// </summary>
        public void ResetRanks()
        {
            foreach (Card card in theHand)
            {
                card.FindRank();
            }
        }

        /// <summary>
        /// Returns the name of the most owned suit based on the amount of Cards of that suit
        /// that exist in theHand.
        /// </summary>
        /// <returns>string</returns>
        public string GetMostOwnedSuit()
        {
            List<Card> countSpades = new List<Card> { };
            List<Card> countHearts = new List<Card> { };
            List<Card> countDiamonds = new List<Card> { };
            List<Card> countClubs = new List<Card> { };

            foreach (Card card in theHand)
            {
                if (card.Code.Contains("S"))
                {
                    countSpades.Add(card);
                }
                else if (card.Code.Contains("H"))
                {
                    countHearts.Add(card);
                }
                else if (card.Code.Contains("D"))
                {
                    countDiamonds.Add(card);
                }
                else if (card.Code.Contains("C"))
                {
                    countClubs.Add(card);
                }
            }

            //List of Card Lists
            List<List<Card>> totals = new List<List<Card>> { countSpades, countHearts, countDiamonds, countClubs };

            totals = totals.OrderByDescending(a => a.Count).ToList();

            if (totals[0] == countSpades)
            {
                return "Spades";
            }
            else if (totals[0] == countHearts)
            {
                return "Hearts";
            }
            else if (totals[0] == countDiamonds)
            {
                return "Diamonds";
            }
            else
            {
                return "Clubs";
            }
        }

        /// <summary>
        /// Returns a List of Card Lists of each suit.
        /// </summary>
        /// <returns>List<List<Card>></returns>
        public List<List<Card>> GetCardsOfEachSuit()
        {
            List<Card> countSpades = new List<Card> { };
            List<Card> countHearts = new List<Card> { };
            List<Card> countDiamonds = new List<Card> { };
            List<Card> countClubs = new List<Card> { };

            foreach (Card card in theHand)
            {
                if (card.Code.Contains("S"))
                {
                    countSpades.Add(card);
                }
                else if (card.Code.Contains("H"))
                {
                    countHearts.Add(card);
                }
                else if (card.Code.Contains("D"))
                {
                    countDiamonds.Add(card);
                }
                else if (card.Code.Contains("C"))
                {
                    countClubs.Add(card);
                }
            }

            //List of Card Lists
            List<List<Card>> totals = new List<List<Card>> { countSpades, countHearts, countDiamonds, countClubs };

            totals = totals.OrderByDescending(a => a.Count).ToList();

            return totals;
        }

        /// <summary>
        /// Populates theHand (List of Cards) with the help of the codes List
        /// </summary>
        public void CreateHand()
        {
            for (int i = 0; i < totalCards; i++)
            {
                theHand.Add(new Card(codes[i]));
            }
        }

        /// <summary>
        /// Return a code at a specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>string</returns>
        public string SeeCode(int index)
        {
            string code = codes[index];
            return code;
        }

        /// <summary>
        /// Sets the isPlayable value of each card in theHand as either true or false
        /// </summary>
        /// <param name="playable"></param>
        public void SetAllPlayable(bool playable)
        {
            foreach (Card card in theHand)
            {
                card.IsPlayable = playable;
            }
        }

        /// <summary>
        /// Sets the isPlayable value of each card that matches the specified suit in theHand as true,
        /// if all cards in the hand are found to be "unplayable", all cards are set to playable instead.
        /// </summary>
        /// <param name="trump"></param>
        public void SetSomePlayable(string trump)
        {
            int unplayable = 0;

            foreach (Card card in theHand)
            {
                //If Card code contains 'S' AND current trump is Spades, set current Card to be playable, etc.
                if (card.Code.Contains("S") && trump == "Spades")
                {
                    card.IsPlayable = true;
                }
                else if (card.Code.Contains("H") && trump == "Hearts")
                {
                    card.IsPlayable = true;
                }
                else if (card.Code.Contains("D") && trump == "Diamonds")
                {
                    card.IsPlayable = true;
                }
                else if (card.Code.Contains("C") && trump == "Clubs")
                {
                    card.IsPlayable = true;
                }
                else
                {
                    unplayable++;
                }
            }

            if (unplayable == theHand.Count)
            {
                SetAllPlayable(true);
            }
        }

        /// <summary>
        /// Removes all Cards in theHand.
        /// </summary>
        public void Delete()
        {
            theHand.Clear();
        }
        #endregion
    }
    #endregion
}
#endregion