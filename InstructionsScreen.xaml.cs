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
#endregion

#region Namespace
namespace Tarneeb
{

    #region InstructionsScreen Class that inherits UserControl
    /// <summary>
    /// Interaction logic for InstructionsScreen.xaml
    /// </summary>
    public partial class InstructionsScreen : UserControl
    {
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes instructions screen.
        /// </summary>
        public InstructionsScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when back button is clicked. Unloads all children of the main windows grid and
        /// loads the home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear(); 

            Control controlHomeScreen = new HomeScreen();
            mainWindow.gridContent.Children.Add(controlHomeScreen); 
        }

        /// <summary>
        /// Occurs when start game button is clicked. Unloads all children of the main windows grid and
        /// loads the offline screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear();

            Control controlOfflineScreen = new OfflineScreen();
            mainWindow.gridContent.Children.Add(controlOfflineScreen);
        }
    }
    #endregion
}
#endregion