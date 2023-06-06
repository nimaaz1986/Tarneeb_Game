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
using Tarneeb.Services;
#endregion

#region Namespace
namespace Tarneeb
{

    #region MainWindow Class
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Attributes
        //Stores the highest bid; used by offline screen
        private int bid;

        //Stores the current trump; used by offline screen
        private string trump;

        //Boolean value used by offline screen that indicates whether to continue the game 
        private bool play;

        //Boolean value used by offline screen that indicates if user has bid
        private bool userHasBid;

        //Stores users bid; used by offline screen
        private int userBid;

        //Stores the name of the team that won; used by game over screen
        private string winningTeam;

        //Stores team ones score; used by game over screen
        private int teamOneScore;

        //Stores team twos score; used by game over screen
        private int teamTwoScore;

        //Stores users name; used by offline screen
        private string userName;

        //Stores user set difficulty; used by offline screen and difficulty pop-up
        private int difficulty;
        #endregion

        /// <summary>
        /// Initializes main window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            Control controlHome = new HomeScreen();
            gridContent.Children.Add(controlHome);

            SetUserName(LoggingService.GetUserNameFromDatabase());

            SetDifficulty(3);
        }

        #region Getters & Setters
        /// <summary>
        /// Sets userBid.
        /// </summary>
        /// <param name="userBid"></param>
        public void SetUserBid(int userBid)
        {
            this.userBid = userBid;
        }

        /// <summary>
        /// Returns userBid.
        /// </summary>
        /// <returns>int</returns>
        public int GetUserBid()
        {
            return this.userBid;
        }

        /// <summary>
        /// Sets bid.
        /// </summary>
        /// <param name="bid"></param>
        public void SetBid(int bid)
        {
            this.bid = bid;
        }

        /// <summary>
        /// Returns bid.
        /// </summary>
        /// <returns>int</returns>
        public int GetBid()
        {
            return this.bid;
        }

        /// <summary>
        /// Sets trump.
        /// </summary>
        /// <param name="trump"></param>
        public void SetTrump(string trump)
        {
            this.trump = trump;
        }

        /// <summary>
        /// Returns trump.
        /// </summary>
        /// <returns>string</returns>
        public string GetTrump()
        {
            return this.trump;
        }

        /// <summary>
        /// Sets play.
        /// </summary>
        /// <param name="play"></param>
        public void SetPlay(bool play)
        {
            this.play = play;
        }

        /// <summary>
        /// Returns play.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetPlay()
        {
            return this.play;
        }

        /// <summary>
        /// Sets userHasBid.
        /// </summary>
        /// <param name="userHasBid"></param>
        public void SetUserHasBid(bool userHasBid)
        {
            this.userHasBid = userHasBid;
        }

        /// <summary>
        /// Returns userHasBid.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetUserHasBid()
        {
            return this.userHasBid;
        }

        /// <summary>
        /// Sets winningTeam.
        /// </summary>
        /// <param name="winningTeam"></param>
        public void SetWinningTeam(string winningTeam)
        {
            this.winningTeam = winningTeam;
        }

        /// <summary>
        /// Returns winningTeam.
        /// </summary>
        /// <returns>string</returns>
        public string GetWinningTeam()
        {
            return this.winningTeam;
        }

        /// <summary>
        /// Sets teamOneScore.
        /// </summary>
        /// <param name="teamOneScore"></param>
        public void SetTeamOneScore(int teamOneScore)
        {
            this.teamOneScore = teamOneScore;
        }

        /// <summary>
        /// Returns teamOneScore.
        /// </summary>
        /// <returns>int</returns>
        public int GetTeamOneScore()
        {
            return this.teamOneScore;
        }

        /// <summary>
        /// Sets teamTwoScore.
        /// </summary>
        /// <param name="teamTwoScore"></param>
        public void SetTeamTwoScore(int teamTwoScore)
        {
            this.teamTwoScore = teamTwoScore;
        }

        /// <summary>
        /// Returns teamTwoScore.
        /// </summary>
        /// <returns>int</returns>
        public int GetTeamTwoScore()
        {
            return this.teamTwoScore;
        }

        /// <summary>
        /// Sets userName.
        /// </summary>
        /// <param name="userName"></param>
        public void SetUserName(string userName)
        {
            this.userName = userName;
        }

        /// <summary>
        /// Returns userName.
        /// </summary>
        /// <returns>string</returns>
        public string GetUserName()
        {
            return this.userName;
        }

        /// <summary>
        /// Sets difficulty.
        /// </summary>
        /// <param name="difficulty"></param>
        public void SetDifficulty(int difficulty)
        {
            this.difficulty = difficulty;
        }

        /// <summary>
        /// Returns difficulty.
        /// </summary>
        /// <returns>int</returns>
        public int GetDifficulty()
        {
            return this.difficulty;
        }
        #endregion
    }
    #endregion
}
#endregion