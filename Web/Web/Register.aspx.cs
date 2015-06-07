using System;
using System.Collections.Generic;
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

        }

        protected async void registerButton_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Username = usernameTextbox.Text;
            user.Password = passwordTextbox.Text;
            user.Email = emailTextbox.Text;

            HttpResponseMessage response = await Database.AddUser(user);

            if (!response.IsSuccessStatusCode)
            {
                ShowError("This username already exists!");
            }
            else
            {
                Session["loggedIn"] = user.Username;

                Server.Transfer("Home.aspx");
            }
        }

        private void ShowError(string errorMessage)
        {
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;
        }
    }
}