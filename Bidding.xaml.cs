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
    #region Bidding Class that inherits UserControl
    /// <summary>
    /// Interaction logic for Bidding.xaml
    /// </summary>
    public partial class Bidding : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes bidding user control.
        /// </summary>
        public Bidding()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sends a bid (integer value ranging 7-13, which is selected by the user) to the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBid_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            ComboBoxItem selectedItem = (ComboBoxItem)cboBidSelect.SelectedItem;
            int selection = Int32.Parse(selectedItem.Content.ToString());

            if (selection > mainWindow.GetBid())
            {
                mainWindow.SetBid(selection);
            }

            mainWindow.SetUserBid(selection);

            mainWindow.SetUserHasBid(true);

            mainWindow.gridContent.Children.Remove(this); 
        }
    }
    #endregion
}
#endregion