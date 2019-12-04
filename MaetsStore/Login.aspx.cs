using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using MaetsStore.Classes;

namespace MaetsStore
{
    public partial class Login : System.Web.UI.Page
    {
        Logic logic = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Submit(object sender, EventArgs e)
        {
            string username = unameId.Value;
            string password = pswId.Value;
            //Checks userinput if user exists
            if (logic.Login(unameId.Value, pswId.Value))
            {
                Session["uname"] = unameId.Value;
                UserManager.UserName = username;
                if (UserManager.CheckIfFileExists(username))
                {
                    UserManager.GamesInLibrary = UserManager.LoadLibrary(username);
                    Debug.WriteLine(UserManager.GamesInLibrary);
                }
                //Makes empty file for the users library
                else
                    UserManager.CreateEmptyUserFile(username);
                Response.Redirect("Default.aspx");
            }
        }
        protected void Button_CreateUser(object sender, EventArgs e)
        {
            string test = Request["unameId"];
            logic.AddUser(unameId.Value, pswId.Value);
        }
    }
}