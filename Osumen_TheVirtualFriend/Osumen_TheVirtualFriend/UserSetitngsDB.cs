using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace Osumen_TheVirtualFriend
{
    class UserSetitngsDB
    {
        public UserSetitngsDB()
        {
            InitializeDB();
        }

        private async static void InitializeDB()
        {
            try
            {
                await ApplicationData.Current.LocalFolder.CreateFileAsync("userSettings.db", CreationCollisionOption.OpenIfExists);
                string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "userSettings.db");

                using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
                {
                    con.Open();
                    string init = "CREATE TABLE IF NOT EXISTS" +
                        "userinfo (" +
                        "Email NVARCHAR(255) PRIMARY KEY, " +
                        "FirstName NVARCHAR(200) NOT NULL, " +
                        "LastName NVARCHAR(200) NOT NULL, " +
                        "UserName NVARCHAR(200) NOT NULL, " +
                        "Password TEXT NOT NULL, " +
                        "DOB Date NOT NULL)";

                    SqliteCommand CMD_createUserTable = new SqliteCommand(init, con);
                    CMD_createUserTable.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception) { }

        }

        /// <summary>
        /// Records the users detals to the client Database
        /// </summary>
        /// <param name="userName">Customized User Name</param>
        /// <returns>true If the Details were recorded successfully. If not False</returns>
        public bool RegisterUser(String userName)
        {
            // To Do : Logic to Insert the details of the user

            /* if user registration success */
            RegisterUserInServer();
            
            return false;
        }

        public bool RegisterUserInServer()
        {
            return false;
        }
    }
}
