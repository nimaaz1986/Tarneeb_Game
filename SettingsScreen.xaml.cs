﻿#region Header
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

    #region SettingsScreen Class that inherits UserControl
    /// <summary>
    /// Interaction logic for SettingsScreen.xaml
    /// </summary>
    public partial class SettingsScreen : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes settings screen.
        /// </summary>
        public SettingsScreen()
        {
            InitializeComponent();
        }

        #region Event Handlers
        /// <summary>
        /// Loads difficulty pop-up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDifficulty_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            Control controlDifficulty = new Difficulty();
            mainWindow.gridContent.Children.Add(controlDifficulty);
        }

        /// <summary>
        /// Occurs when change name button is clicked. Loads user name control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeName_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            Control controlUserName = new UserName();
            mainWindow.gridContent.Children.Add(controlUserName);
        }

        /// <summary>
        /// Occurs when back button is clicked. Unloads all children of the main windows grid and
        /// then loads home screen.
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
        /// Occurs when stats button is clicked. Loads stats screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            Control controlStatsScreen = new StatsScreen();
            mainWindow.gridContent.Children.Add(controlStatsScreen);
        }

        /// <summary>
        /// Occurs when reset button is clicked. Asks the user for confirmation to continue resetting the
        /// database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            if (MessageBox.Show("This will reset your stats, username, and logged data. Do you wish to proceed?", 
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                LoggingService.ResetDatabase();
                mainWindow.SetUserName("Player One");
                mainWindow.SetDifficulty(3);
            }
        }
        #endregion
    }
    #endregion
}
#endregion