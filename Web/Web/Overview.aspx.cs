using System;
using System.Collections.Generic;
using System.Drawing;
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
                try
                {
                    Users currentUser = (Users)Session["loggedIn"];
                    List<Users> users = await Database.GetUsersCloseToSystem(currentUser.SystemId, Convert.ToInt32(lightyearValueLabel.Text));

                    foreach(Users user in users)
                    {
                        if (user.Username != currentUser.Username)
                        {
                            Systems system = await Database.GetSystemById(user.SystemId);

                            commandersListbox.Items.Add("CMDR " + user.Username + " -> " + system.Name);
                        }
                    }
                }
                catch
                {
                    ShowError("There was an error getting the data!", Color.Red);
                }
            }            
        }

        private void ShowError(string errorMessage, Color color)
        {
            errorLabel.ForeColor = color;
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;
        }
    }
}