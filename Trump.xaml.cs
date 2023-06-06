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

    #region Trump Class that inherits UserControl
    /// <summary>
    /// Interaction logic for Trump.xaml
    /// </summary>
    public partial class Trump : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes the trump control.
        /// </summary>
        public Trump()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the confrim button is clicked. Sends values (trump and a boolean value) to the main window. 
        /// The trump sent is based on the selected radio button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            if (rbSpades.IsChecked == true || rbHearts.IsChecked == true || rbDiamonds.IsChecked == true || rbClubs.IsChecked == true)
            {
                mainWindow.gridContent.Children.Remove(this);

                string selection = "";

                if (rbSpades.IsChecked == true)
                {
                    selection = "Spades";
                }
                else if (rbHearts.IsChecked == true)
                {
                    selection = "Hearts";
                }
                else if (rbDiamonds.IsChecked == true)
                {
                    selection = "Diamonds";
                }
                else if (rbClubs.IsChecked == true)
                {
                    selection = "Clubs";
                }

                mainWindow.SetTrump(selection);
                mainWindow.SetPlay(true);
            }
        }
    }
    #endregion
}
#endregion