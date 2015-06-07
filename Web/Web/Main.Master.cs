using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["test"] = "Dit is een test";

            if (Session["loggedIn"] != null)
            {
                Users user = (Users)Session["loggedIn"];
                usernameLabel.Text = "Welcome back, CMDR " + user.Username + "!";
                userLink.NavigateUrl = "Userpage.aspx?Username=" + user.Username;
                loggedInPanel.Visible = true;
            }
            else
            {
                loggedOutPanel.Visible = true;
            }
        }
    }
}