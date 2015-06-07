using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorPanel.Visible = false;  
        }

        protected async void loginButton_Click(object sender, EventArgs e)
        {
            Users user = await Database.GetUserByUsername(usernameTextbox.Text);

            if (user != null)
            {
                if (user.Password == passwordTextbox.Text)
                {
                    Session["loggedIn"] = user;

                    Server.Transfer("Home.aspx");
                }
                else
                {
                    ShowError("This combination does not exist!");
                }
            }
            else
            {
                ShowError("This combination does not exist!");
            }
        }

        private void ShowError(string errorMessage)
        {
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;  
        }
    }
}