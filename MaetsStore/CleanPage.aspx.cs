using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaetsStore.Classes;

namespace MaetsStore
{
    public partial class CleanPage : System.Web.UI.Page
    {
        int gameId;

        protected void Page_Load(object sender, EventArgs e)
        {
            gameId = Convert.ToInt32(Request.QueryString["GameId"]);
        }


        public Game GetProduct()
        {
            return GameFactory.games[gameId];
        }

        public void AddProductToBasket(object o, EventArgs e)
        {
            StockValidation stockValidater = new StockValidation();
            
            if (stockValidater.IsThereStock(GameFactory.games[gameId]))
            {
                System.Diagnostics.Debug.WriteLine("There was stock");
                UserManager.GamesInBasket.Add(GameFactory.games[gameId]);
                Response.Redirect("Store.aspx");
            }
            System.Diagnostics.Debug.WriteLine("Not enough stock!");
        }
    }
}