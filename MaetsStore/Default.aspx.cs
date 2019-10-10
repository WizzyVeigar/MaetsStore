using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaetsStore
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["uname"] != null)
                {
                    HelloText.InnerText = "Hello " + (string)Session["uname"] + "!";

                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}