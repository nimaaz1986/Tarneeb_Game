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
using System.Windows.Media;
using Tarneeb.Animation;
using Tarneeb.Services;
#endregion

#region Namespace
namespace Tarneeb
{

    #region GameOverScreen Class that inherits UserControl
    /// <summary>
    /// Interaction logic for GameOverScreen.xaml
    /// </summary>
    public partial class GameOverScreen : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes game over screen. Sets up the screen by getting values from main window.
        /// </summary>
        public GameOverScreen()
        {
            InitializeComponent();

            lblScore1.Content = mainWindow.GetTeamOneScore();
            lblScore2.Content = mainWindow.GetTeamTwoScore();
            txtWinner.Text = mainWindow.GetWinningTeam();

            if (mainWindow.GetWinningTeam() == "OPPONENT TEAM")
            {
                recColour.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                LoggingService.UpdateGameStats(false);
            }
            else if (mainWindow.GetWinningTeam() == "YOUR TEAM")
            {
                LoggingService.UpdateGameStats(true);
            }

            //Resetting the values
            mainWindow.SetTeamOneScore(0);
            mainWindow.SetTeamTwoScore(0);
            mainWindow.SetWinningTeam("");
        }

        #region Event Handlers
        /// <summary>
        /// Occurs when main menu button is clicked. Unloads all children of the main windows grid and
        /// then loads home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear();

            Control homeScreen = new HomeScreen();
            mainWindow.gridContent.Children.Add(homeScreen);
        }

        /// <summary>
        /// Occurs when replay button is clicked. Unloads all children of the main windows grid and
        /// then loads offline screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear();

            Control offlineScreen = new OfflineScreen();
            mainWindow.gridContent.Children.Add(offlineScreen);
        }
        #endregion
    }
    #endregion
}
#endregion