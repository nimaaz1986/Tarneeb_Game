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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
#endregion

#region Namespace
namespace Tarneeb
{
    #region Card Class
    public class Card
    {
        #region Class Attributes
        //Stores the Card Image
        public Image TheCard { get; set; }

        //Stores the Cards rank
        public int TheRank { get; set; }

        //Stores the Cards suit
        public string TheSuit { get; set; }

        //Stores the Cards Code
        public string Code { get; set; }

        //Stores if Card is playable or not
        public bool IsPlayable { get; set; }

        //Stores if Card has been played or not
        public bool IsPlayed { get; set; }

        //Stores who the card is owned by
        public int OwnedBy { get; set; }
        #endregion


        /// <summary>
        /// Parameterized Constructor
        /// Finds the card image, rank, and suit based on card code provided. Initially sets IsPlayable as false, sets width and height
        /// of the image, gives the image a hover effect, and a click effect.
        /// </summary>
        /// <param name="code"></param>
        public Card(string code)
        {
            IsPlayable = false;

            this.Code = code;

            TheCard = new Image();


            BitmapImage image = new BitmapImage(new Uri("/Tarneeb;component/Images/CardsPNG/" + code + ".png", UriKind.Relative));
            TheCard.Source = image;

            FindRank();
            FindSuit();

            TheCard.Width = 80;
            TheCard.Height = 130;
            TheCard.HorizontalAlignment = HorizontalAlignment.Center;
            TheCard.VerticalAlignment = VerticalAlignment.Center;


            TheCard.MouseEnter += MouseEnter_Card;
            TheCard.MouseLeave += MouseLeave_Card;


            TheCard.MouseUp += Click_Card;
        }

        #region Methods
        /// <summary>
        /// This method sets the Card's rank based on the card code.
        /// </summary>
        public void FindRank()
        {
            if (Code.Contains("2"))
            {
                TheRank = 1;
            }
            else if (Code.Contains("3"))
            {
                TheRank = 2;
            }
            else if (Code.Contains("4"))
            {
                TheRank = 3;
            }
            else if (Code.Contains("5"))
            {
                TheRank = 4;
            }
            else if (Code.Contains("6"))
            {
                TheRank = 5;
            }
            else if (Code.Contains("7"))
            {
                TheRank = 6;
            }
            else if (Code.Contains("8"))
            {
                TheRank = 7;
            }
            else if (Code.Contains("9"))
            {
                TheRank = 8;
            }
            else if (Code.Contains("0"))
            {
                TheRank = 9;
            }
            else if (Code.Contains("J"))
            {
                TheRank = 10;
            }
            else if (Code.Contains("Q"))
            {
                TheRank = 11;
            }
            else if (Code.Contains("K"))
            {
                TheRank = 12;
            }
            else if (Code.Contains("A"))
            {
                TheRank = 13;
            }
        }

        /// <summary>
        /// Finds the Card's stui based on the card Code
        /// </summary>
        public void FindSuit()
        {
            if (Code.Contains("S"))
            {
                TheSuit = "Spades";
            }
            else if (Code.Contains("H"))
            {
                TheSuit = "Hearts";
            }
            else if (Code.Contains("D"))
            {
                TheSuit = "Diamonds";
            }
            else if (Code.Contains("C"))
            {
                TheSuit = "Clubs";
            }
        }

        /// <summary>
        /// Changes the position of an image based on the specified location.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        public void Play(Image image, int y1, int y2, int x1, int x2)
        {
            image.Width = 80;
            image.Height = 130;
            image.Visibility = Visibility.Visible;
            image.Margin = new System.Windows.Thickness(y1, y2, x1, x2);
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Occurs when cursor enters the image space. Image becomes enlargened only if the card is playable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnter_Card(object sender, MouseEventArgs e)
        {
            if (IsPlayable)
            {
                Image image = (Image)sender;
                image.Width = 100;
                image.Height = 150;
            }
        }

        /// <summary>
        /// Occurs when cursor leaves the image space. Image becomes smaller only if the card is playable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeave_Card(object sender, MouseEventArgs e)
        {
            if (IsPlayable)
            {
                Image image = (Image)sender;
                image.Width = 80;
                image.Height = 130;
            }
        }

        /// <summary>
        /// Occurs when the card image is clicked. Image moves from the users list of cards (on screen) area 
        /// to the users play card area only if the card is playable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Card(object sender, MouseEventArgs e)
        {
            if (IsPlayable)
            {
                Image image = (Image)sender;
                image.Visibility = Visibility.Collapsed;
                this.IsPlayed = true;
                Play(image, 0, 250, 0, 0);
            }
        }
        #endregion
    }
    #endregion
}
#endregion
