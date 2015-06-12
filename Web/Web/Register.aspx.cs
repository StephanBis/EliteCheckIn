using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorPanel.Visible = false;
        }

        protected async void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();
                user.Username = usernameTextbox.Text;
                user.Password = passwordTextbox.Text;
                user.Email = emailTextbox.Text;

                HttpResponseMessage response = await Database.AddUser(user);

                if (!response.IsSuccessStatusCode)
                {
                    ShowError("This username already exists!", Color.Red);
                }
                else
                {
                    Session["loggedIn"] = user.Username;

                    Server.Transfer("Home.aspx");
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