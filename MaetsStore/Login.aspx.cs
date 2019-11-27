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
        protected void Button_Submit(object sender, System.EventArgs e)
        {
            string username = unameId.Value;
            string password = pswId.Value;
            if (logic.Login(unameId.Value, pswId.Value))
            {
                UserManager.UserName = username;
                Session["uname"] = unameId.Value;
                UserManager.SessionID = Session["uname"].ToString();
                Response.Redirect("Default.aspx");
            }
        }
        protected void Button_CreateUser(object sender, System.EventArgs e)
        {
            string test = Request["unameId"];
            logic.AddUser(unameId.Value, pswId.Value);
        }
    }
}