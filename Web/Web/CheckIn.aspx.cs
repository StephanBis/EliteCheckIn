using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class CheckIn : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                Server.Execute("Login.aspx");
            }
            else
            {
                errorPanel.Visible = false;

                if (!IsPostBack)
                {
                    Users user = (Users)Session["loggedIn"];
                    Systems system = await Database.GetSystemById(user.SystemId);

                    if (!(user.SystemId == -1))
                    {
                        systemTextbox.Text = system.Name;
                    }
                    else
                    {
                        systemTextbox.Text = "Unknown";
                    }
                }
            }
        }

        protected async void checkInButton_Click(object sender, EventArgs e)
        {
            Users user = (Users)Session["loggedIn"];
            List<Systems> systems = await Database.GetSystemsByFilter(systemTextbox.Text.Replace(".", "|"));
            bool found = false;

            if (systems.Count > 0)
            {
                foreach(Systems system in systems)
                {
                    if (system.Name == systemTextbox.Text)
                    {
                        user.SystemId = Convert.ToInt32(system.Id);

                        HttpResponseMessage response = await Database.SaveUser(user);

                        if (!response.IsSuccessStatusCode)
                        {
                            ShowError("Unable to check-in!", Color.Red);
                        }

                        found = true;
                        ShowError("Your location has been updated!", Color.Green);
                        break;
                    }
                }

                if (found == false)
                {
                    ShowError("This system does not exist!", Color.Red);
                }
            }
            else
            {
                ShowError("This system does not exist!", Color.Red);
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