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
using Tarneeb.Animation;
#endregion

#region Namespace
namespace Tarneeb
{

    #region HomeScreen Class that inherits UserControl
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes home screen.
        /// </summary>
        public HomeScreen()
        {
            InitializeComponent();
        }

        #region Event Handlers
        /// <summary>
        /// Occurs when the play button is clicked. Unloads all children of the main windows grid and
        /// loads the offline screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            //Initiate Offline Mode
            mainWindow.gridContent.Children.Clear(); 

            Control controlOfflineScreen = new OfflineScreen();
            mainWindow.gridContent.Children.Add(controlOfflineScreen); 
        }

        /// <summary>
        /// Occurs when how to play button is clicked. Unloads all children of the main windows grid and
        /// loads the instructions screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHowTo_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear();

            Control controlInstructionsScreen = new InstructionsScreen();
            mainWindow.gridContent.Children.Add(controlInstructionsScreen);
        }

        /// <summary>
        /// Occurs when the settings button is clicked. Unloads all children of the main windows grid and
        /// loads the settings screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear();

            Control controlSettingsScreen = new SettingsScreen();
            mainWindow.gridContent.Children.Add(controlSettingsScreen);
        }

        /// <summary>
        /// Closes application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            Environment.Exit(0);
        }
        #endregion

        /// <summary>
        /// Occurs when the settings button is clicked. Unloads all children of the main windows grid and
        /// loads the about us screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Clear();

            Control controlAboutScreen = new AboutScreen();
            mainWindow.gridContent.Children.Add(controlAboutScreen);
        }
    }
    #endregion
}
#endregion