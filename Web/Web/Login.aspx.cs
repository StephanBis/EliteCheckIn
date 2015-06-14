using System;
using System.Collections.Generic;
using System.Drawing;
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

            if (Session["error"] != null)
            {
                ShowError(Session["error"].ToString(), Color.Red);
                Session["error"] = null;
            }
        }

        protected async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = await Database.GetUserByUsername(usernameTextbox.Text);

                if (user != null)
                {
                    if (Hash.VerifyHash(passwordTextbox.Text, "MD5", user.Hash) == true)
                    {
                        Session["loggedIn"] = user;

                        if (Session["page"] != null)
                        {
                            Server.Transfer(Session["page"].ToString());
                        }
                        else
                        {
                            Server.Transfer("Home.aspx");
                        }
                    }
                    else
                    {
                        ShowError("This combination does not exist!", Color.Red);
                    }
                }
                else
                {
                    ShowError("This combination does not exist!", Color.Red);
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