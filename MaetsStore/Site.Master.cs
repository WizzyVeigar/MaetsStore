using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MaetsStore.Classes;

namespace MaetsStore
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void UserLogOut(object sender, EventArgs e)
        {
            if(UserManager.GamesInLibrary != null)
                UserManager.GamesInLibrary.Clear();

            if(UserManager.GamesInBasket != null)
                UserManager.GamesInBasket.Clear();
            if (Session["uname"] != null)
            {
                //logOutButton.InnerText = "Logout";
                //Session["uname"] = null;
                //Response.Redirect("Login.aspx");
                //logOutButton.HRef = "Login.aspx";
                logOutButton.Text = "Logout";
                Session["uname"] = null;
                Response.Redirect("Login.aspx");
                //logOutButton. = "Login.aspx";
            }
            else
                Response.Redirect("Login.aspx");
        }        
    }
}