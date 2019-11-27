using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}