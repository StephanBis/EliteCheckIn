using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Overview : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                Server.Execute("Login.aspx");
            }
            else
            {
                Users currentUser = (Users)Session["loggedIn"];
                List<Users> users = await Database.GetUsersCloseToSystem(currentUser.SystemId, 10);

                foreach(Users user in users)
                {
                    if (user.Username != currentUser.Username)
                    {
                        Systems system = await Database.GetSystemById(user.SystemId);

                        commandersListbox.Items.Add("CMDR " + user.Username + " -> " + system.Name);
                    }
                }
            }            
        }
    }
}