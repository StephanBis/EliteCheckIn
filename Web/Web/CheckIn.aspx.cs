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
            Session["page"] = "CheckIn.aspx";

            if (Session["loggedIn"] == null)
            {
                Session["error"] = "You must be logged in to access this page!";
                Server.Execute("Login.aspx");
            }
            else
            {
                errorPanel.Visible = false;

                if (!IsPostBack)
                {
                    try
                    {
                        Users user = (Users)Session["loggedIn"];
                        Systems system = await Database.GetSystemById(user.SystemId);

                        if (!(user.SystemId <= 0))
                        {
                            systemTextbox.Text = system.Name;
                        }
                        else
                        {
                            systemTextbox.Text = "Unknown";
                        }
                    }
                    catch
                    {
                        ShowError("There was an error getting the data!", Color.Red);
                    }
                }
            }
        }

        protected async void checkInButton_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = (Users)Session["loggedIn"];
                Systems system = await Database.GetSystemByName(systemTextbox.Text.ToLower().Replace(".", "|"));

                if (system != null)
                {
                    user.SystemId = Convert.ToInt32(system.Id);

                    HttpResponseMessage response = await Database.SaveUser(user);

                    if (!response.IsSuccessStatusCode)
                    {
                        ShowError("Unable to check-in!", Color.Red);
                    }

                    ShowError("Your location has been updated!", Color.Green);
                }
                else
                {
                    ShowError("This system does not exist!", Color.Red);
                }
            }
            catch
            {
                ShowError("There was an error getting the data!", Color.Red);
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