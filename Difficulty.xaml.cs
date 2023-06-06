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

    #region Difficulty Class that inherits UserControl
    /// <summary>
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class Difficulty : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes difficulty user control. Remembers the user set difficulty.
        /// </summary>
        public Difficulty()
        {
            InitializeComponent();

            if (mainWindow.GetDifficulty() == 1)
            {
                rbEasy.IsChecked = true;
            }
            else if (mainWindow.GetDifficulty() == 2)
            {
                rbMedium.IsChecked = true;
            }
            else if (mainWindow.GetDifficulty() == 3)
            {
                rbHard.IsChecked = true;
            }
        }

        /// <summary>
        /// Occurs when the confirm button is clicked. Changes the difficulty value in main window based on the
        /// selected radio button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            if (rbEasy.IsChecked == true)
            {
                mainWindow.SetDifficulty(1);
            }
            else if (rbMedium.IsChecked == true)
            {
                mainWindow.SetDifficulty(2);
            }
            else if (rbHard.IsChecked == true)
            {
                mainWindow.SetDifficulty(3);
            }

            mainWindow.gridContent.Children.Remove(this);
        }
    }
    #endregion
}
#endregion