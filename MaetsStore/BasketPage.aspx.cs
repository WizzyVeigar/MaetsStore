using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaetsStore.Classes;

namespace MaetsStore
{
    public partial class BasketPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowBasketTotal();
        }

        private void ShowBasketTotal()
        {
            float total = 0;
            foreach (Game game in UserManager.GamesInBasket)
            {
                total += game.GamePrice;
            }
            TotalNumber.Text = total.ToString();
        }

        public List<Game> LoadBasket()
        {
            if (UserManager.GamesInBasket.Count == 0)
                return null;
            return UserManager.GamesInBasket;
        }

        protected void BtnFinishPurchase_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Clicked");
        }
    }
}