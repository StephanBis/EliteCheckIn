using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Systems1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "Systems.aspx";

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

                        if (user.Score > 50)
                        {
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
                        else
                        {
                            systemPanel.Visible = false;
                            ShowError("You do not have the rank for this!", Color.Red);
                        }
                    }
                    catch
                    {
                        ShowError("There was an error getting the data!", Color.Red);
                    }
                }
            }
        }

        protected void getButton_Click(object sender, EventArgs e)
        {

        }

        private void ShowError(string errorMessage, Color color)
        {
            errorLabel.ForeColor = color;
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;
        }
    }
}