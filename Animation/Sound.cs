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
using System.IO;
using System.Reflection;
#endregion

#region Namespace
namespace Tarneeb.Animation
{

    #region Sound Class
    public class Sound
    {
        /// <summary>
        /// Locates and plays a button clicking sound. Used for all buttons.
        /// </summary>
        public static void PlayButtonClick()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Sounds\button_click.wav");
            player.Play();
        }

        /// <summary>
        /// Locates and plays a card swiping sound. Used for handing out cards.
        /// </summary>
        public static void PlayCardSwipe()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Sounds\card_swipe.wav");
            player.Play();
        }

        /// <summary>
        /// Locates and plays a card clicking sound. Used for playing a card.
        /// </summary>
        public static void PlayCardClick()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\Sounds\card_click.wav");
            player.Play();
        }
    }
    #endregion
}
#endregion