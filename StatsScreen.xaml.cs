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
using System.Windows;
using System.Windows.Controls;
using Tarneeb.Animation;
using Tarneeb.Services;
#endregion

#region Namespace
namespace Tarneeb
{

    #region StatsScreen Class that inherits UserControl
    /// <summary>
    /// Interaction logic for StatsScreen.xaml
    /// </summary>
    public partial class StatsScreen : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes stats screen. Gets wins, losses, games played from the database, and displays
        /// them.
        /// </summary>
        public StatsScreen()
        {
            InitializeComponent();

            lblWins.Content = LoggingService.GetWins();
            lblLosses.Content = LoggingService.GetLosses();
            lblGamesPlayed.Content = LoggingService.GetGamesPlayed();
        }

        /// <summary>
        /// Occurs when back button is clicked. Removes itself.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Remove(this);
        }
    }
    #endregion
}
#endregion