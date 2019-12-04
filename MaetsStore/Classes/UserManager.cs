using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MaetsStore.Classes
{
    public static class UserManager
    {
        private static string userName;
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private static string sessionID;
        public static string SessionID
        {
            get { return sessionID; }
            set { sessionID = value; }
        }

        private static string librarypath;

        public static string LibraryPath
        {
            get { return librarypath; }
            set { librarypath = value; }
        }

        private static List<Game> gamesInBasket = new List<Game>();
        public static List<Game> GamesInBasket
        {
            get { return gamesInBasket; }
            set { gamesInBasket = value; }
        }

        private static List<Game> gamesInLibrary;
        public static List<Game> GamesInLibrary
        {
            get { return gamesInLibrary; }
            set { gamesInLibrary = value; }
        }
        //public UserManager(string userName, string sessionID)
        //{
        //    UserName = userName;
        //    SessionID = sessionID;
        //}
        #region SaveUserGames
        static string finalString = Path.GetTempPath();
        public static void SaveLibrary(List<Game> boughtGames)
        {
            string jstring = SerializeToString(boughtGames);
            EncryptLibrary(jstring);
        }

        private static string SerializeToString(List<Game> boughtGames)
        {
            string jString = JsonConvert.SerializeObject(boughtGames);
            return jString;
        }

        private static void EncryptLibrary(string pathToLib)
        {
            Encryption.EncryptJson(pathToLib);
            SaveStringToFile(pathToLib);
        }

        private static void SaveStringToFile(string textToSave)
        {
            if (Directory.Exists(finalString + "MaetsStore/Users"))
            {
                if (UserName == null)
                    UserName = "TestBob";
                System.Diagnostics.Debug.WriteLine(UserName);
                File.WriteAllText(finalString + "/MaetsStore/Users/" + UserName + ".json", textToSave);
            }
            else
            {
                Directory.CreateDirectory(finalString + "MaetsStore/Users");
                File.WriteAllText(finalString + "/MaetsStore/Users/" + UserName + ".json", textToSave);
            }

            System.Diagnostics.Debug.WriteLine("I am done saving");
        }
        #endregion
        #region LoadUserGames
        internal static List<Game> LoadLibrary(string username)
        {           
                string ecyptedString = ReadFromFile(username);
                string decrypted = DecryptString(ecyptedString);

                return SerializeJson(decrypted);
        }

        private static List<Game> SerializeJson(string decryptedString)
        {

            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(decryptedString);
            return games;
        }

        private static string ReadFromFile(string nameOfUser)
        {
            if (Directory.Exists(finalString + "MaetsStore/Users/") && File.Exists(finalString + "/MaetsStore/Users/" + nameOfUser + ".json"))
                return File.ReadAllText(finalString + "/MaetsStore/Users/" + nameOfUser + ".json");
            return null;
        }

        private static string DecryptString(string encryptedString)
        {
            return Encryption.DecryptJson(encryptedString);
        }

        public static bool CheckIfFileExists(string file)
        {
            if (Directory.Exists(finalString + "MaetsStore/Users/") && File.Exists(finalString + "/MaetsStore/Users/" + file + ".json"))
                return true;
            return false;
        }
        //I was too lazy to create a new class
        public static void CreateEmptyUserFile(string name)
        {
            Directory.CreateDirectory(finalString + "MaetsStore/Users");
            File.WriteAllText(finalString + "/MaetsStore/Users/" + name + ".json", "");
        }
        #endregion
    }
}