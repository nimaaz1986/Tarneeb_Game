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
using System.Data.SqlClient;
using System.Windows;
#endregion

#region Namespace
namespace Tarneeb.Services
{

    #region LoggingService Class
    /// <summary>
    /// A class to run query for different operation in database.
    /// </summary>
    public class LoggingService
    {
        static string connectionString = Properties.Settings.Default.TarneebDatabaseConnectionStringRelative;

        /// <summary>
        /// Method to log specific event detail into the database.
        /// </summary>
        /// <param name="trigger">A trigger.</param>
        /// <param name="sqlEvent">A sql event.</param>
        public static void Log(string trigger, string sqlEvent)
        {
            // Get current time to log.
            DateTime eventDateTime = DateTime.Now;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string insertQuery = "INSERT INTO [Logging]([LogID], [Trigger], [Event], [TimeOccurred]) " +
                    "VALUES((SELECT ISNULL(MAX(LogID) + 1, 1) FROM [Logging]), '" + trigger + "', '" + sqlEvent + "', '" + eventDateTime + "')";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Update game stats based on given win value.
        /// </summary>
        /// <param name="win"></param>
        public static void UpdateGameStats(bool win)
        {
            string updateQuery = null;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                if (win)
                {
                    updateQuery = "UPDATE UserStats SET Wins = Wins + 1, GamesPlayed = GamesPlayed + 1 WHERE PlayerID = 1";
                }
                else if (!win)
                {
                    updateQuery = "UPDATE UserStats SET Losses = Losses + 1, GamesPlayed = GamesPlayed + 1 WHERE PlayerID = 1";
                }

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Method to retrieve the user name from database.
        /// </summary>
        /// <returns>A found username.</returns>
        public static string GetUserNameFromDatabase()
        {
            string name = null;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string selectQuery = "SELECT PlayerName FROM UserStats WHERE PlayerID = 1";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                name = ((string)command.ExecuteScalar()).Trim();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return name;
        }

        /// <summary>
        /// Sets the users name in UserStats table.
        /// </summary>
        /// <param name="name"></param>
        public static void SetUserNameInDatabase(string name)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string updateQuery = "UPDATE UserStats SET PlayerName = '" + name + "' WHERE PlayerID = 1";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Gets the number of wins from database.
        /// </summary>
        /// <returns>Number of wins as a string.</returns>
        public static string GetWins()
        {
            int numberOfWins = 0;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string selectQuery = "SELECT Wins FROM UserStats WHERE PlayerID = 1";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                numberOfWins = (int)command.ExecuteScalar();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return numberOfWins.ToString();
        }

        /// <summary>
        /// Gets the number of losses from the database.
        /// </summary>
        /// <returns>string</returns>
        public static string GetLosses()
        {
            int numberOfLosses = 0;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string selectQuery = "SELECT Losses FROM UserStats WHERE PlayerID = 1";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                numberOfLosses = (int)command.ExecuteScalar();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return numberOfLosses.ToString();
        }

        /// <summary>
        /// Gets the number of games played in past.
        /// </summary>
        /// <returns>string</returns>
        public static string GetGamesPlayed()
        {
            int gamesPlayed = 0;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string selectQuery = "SELECT GamesPlayed FROM UserStats WHERE PlayerID = 1";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                gamesPlayed = (int)command.ExecuteScalar();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return gamesPlayed.ToString();
        }

        /// <summary>
        /// Resets the database.
        /// </summary>
        public static void ResetDatabase()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string deleteQuery = "DELETE FROM Logging";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.ExecuteNonQuery();

                 string updateQuery = "UPDATE UserStats SET PlayerName = 'Player One', Wins = 0, " +
                    "Losses = 0, GamesPlayed = 0 WHERE PlayerID = 1";

                command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    #endregion
}
#endregion