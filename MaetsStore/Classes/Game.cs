using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaetsStore.Classes
{
    public class Game
    {
        private int gameid;
        public int GameId
        {
            get { return gameid; }
            set { gameid = value; }
        }

        private string gamename;
        public string GameName
        {
            get { return gamename; }
            set { gamename = value; }
        }

        private int gameamount;
        public int GameAmount
        {
            get { return gameamount; }
            set { gameamount = value; }
        }

        private float gameprice;
        public float GamePrice
        {
            get { return gameprice; }
            set { gameprice = value; }
        }

        private string gamedesc;
        public string GameDesc
        {
            get { return gamedesc; }
            set { gamedesc = value; }
        }

        private string gameimagepath;
        public string GameImagePath
        {
            get { return gameimagepath; }
            set { gameimagepath = value; }
        }

        public Game(string name, int amount, float price, string imagepath)
        {
            GameName = name;
            GameAmount = amount;
            GamePrice = price;
            GameImagePath = imagepath;
        }
    }
}