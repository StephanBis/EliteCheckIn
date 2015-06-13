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
            Session["temp"] = "";

            if (!IsPostBack)
            {
                if (Session["loggedIn"] != null)
                {
                    Users user = (Users)Session["loggedIn"];
                    usernameLabel.Text = "Welcome back, CMDR " + user.Username + "!";
                    userLink.NavigateUrl = "Userpage.aspx?Username=" + user.Username;
                    searchTextbox.Style["margin-right"] = "0";
                    loggedInPanel.Visible = true;
                    loggedOutPanel.Visible = false;
                }
                else
                {
                    loggedOutPanel.Visible = true; 
                    loggedInPanel.Visible = false;
                }
            }
        }

        protected void searchTextbox_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("Userpage.aspx?Username=" + searchTextbox.Text);
            //Server.Transfer("Userpage.aspx?Username=" + searchTextbox.Text);
        }
    }
}