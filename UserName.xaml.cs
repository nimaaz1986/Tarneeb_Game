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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Tarneeb.Animation;
using Tarneeb.Services;
#endregion

#region Namespace
namespace Tarneeb
{
    #region Username Class that inherits UserControl
    /// <summary>
    /// Interaction logic for UserName.xaml
    /// </summary>
    public partial class UserName : UserControl
    {
        //Accessing main window
        MainWindow mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);

        /// <summary>
        /// Initializes user name control
        /// </summary>
        public UserName()
        {
            InitializeComponent();
        }

        private void btnUserNameEntryField_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            //Defining illegal characters
            var regexItem = new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");

            //If nothing entered
            if (txtUserNameEntryField.Text.Length == 0)
            {
                MessageBox.Show("Please enter your name. You can't leave it blank!");
            }
            //If input matches illegal characters
            else if (regexItem.IsMatch(txtUserNameEntryField.Text.ToString().Trim()))
            {
                MessageBox.Show("Please enter a valid name!");
            }
            //If input too long
            else if (txtUserNameEntryField.Text.Length > 20)
            {
                MessageBox.Show("Name cannot be longer than 20 chars!");
            }
            //Else if no errors
            else
            {
                //Set user name in main window (so it's accessible by all controls)
                mainWindow.SetUserName(txtUserNameEntryField.Text);

                //Set user name in database (so the application won't forget the name)
                LoggingService.SetUserNameInDatabase(txtUserNameEntryField.Text);

                MessageBox.Show("Your name is successfully changed to \"" + txtUserNameEntryField.Text + "\"");

                mainWindow.gridContent.Children.Remove(this); //remove self
            }
        }

        /// <summary>
        /// Occurs when cancel button is clicked. Removes itself.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayButtonClick();

            mainWindow.gridContent.Children.Remove(this);
        }
    }
    #endregion
}
#endregion