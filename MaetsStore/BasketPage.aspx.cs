using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaetsStore.Classes;
using System.Diagnostics;

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
            UserManager.GamesInLibrary = UserManager.GamesInBasket;
            UserManager.SaveLibrary(UserManager.GamesInBasket);
            Response.Redirect("BasketPage.aspx");
        }



        protected void RemoveItem_Click(object sender, EventArgs e)
        {
            Button gm = (Button)sender;
            //Debug.WriteLine("button prints id: " +  gm.Parent.UniqueID + " gm text" + gm.Text);
            //Debug.WriteLine("Gm text: " + Convert.ToInt32(gm.Text));
            int pos = 0;
            for (int i = 0; i < UserManager.GamesInBasket.Count; i++)
            {
                if (UserManager.GamesInBasket[i].GameId == Convert.ToInt32(gm.Text))
                    pos = i;
            }
            UserManager.GamesInBasket.RemoveAt(pos);

            Response.Redirect("BasketPage.aspx");
        }
    }
}