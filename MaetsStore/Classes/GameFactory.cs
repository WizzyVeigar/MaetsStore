using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaetsStore.Classes;

namespace MaetsStore.Classes
{
    public class GameFactory
    {
        Logic logic = new Logic();
        public static List<Game> games = new List<Game>();

        public List<Game> MakeGames()
        {
            if (games.Count != 0)
                games.Clear();
            //DataTable dt = logic.GetDb();
            using (DataTable dt = logic.GetDb())
            {
                int id = 0;
                string rowName;
                int rowAmount;
                float rowPrice;
                string rowDesc;
                string rowImage = "";
                string[] gameImages = logic.GetGameImages(dt);

                foreach (DataRow row in dt.Rows)
                {
                    rowName = row[1].ToString().ToLower();
                    rowAmount = Convert.ToInt32(row[2]);
                    rowPrice = float.Parse(row[3].ToString());
                    rowDesc = row[4].ToString();
                    foreach (string path in gameImages)
                    {
                        path.ToLower();
                        if (path.Contains(rowName))
                        {
                            rowImage = rowName + ".png";
                            gameImages = gameImages.Where(s => s != path).ToArray();
                            break;
                        }
                    }
                    games.Add(new Game(rowName, rowAmount, rowPrice, rowDesc, rowImage, id));
                    id++;
                }
                foreach (Game game in games)
                {
                    Debug.WriteLine(game.GameName + game.GameId);
                }
                Debug.WriteLine(games.Count);
            }
            return games;
        }
    }
}