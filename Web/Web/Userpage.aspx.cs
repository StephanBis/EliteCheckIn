using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Userpage : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggedIn"] != null)
                {
                    Users user = (Users)Session["loggedIn"];
                    string username = Request.QueryString["Username"];

                    if (username == user.Username)
                    {
                        usernameEditLabel.Text = "CMDR " + user.Username;
                        passwordTextbox.Text = user.Password;
                        emailTextbox.Text = user.Email;

                        Systems system = await Database.GetSystemById(user.SystemId);
                        if (!(user.SystemId == -1))
                        {
                            systemEditLabel.Text = system.Name;
                        }
                        else
                        {
                            systemEditLabel.Text = "Unknown";
                        }

                        systemLink.NavigateUrl = "CheckIn.aspx";
                        editPanel.Visible = true;
                    }
                    else
                    {
                        Users queryUser = await Database.GetUserByUsername(Request.QueryString["Username"]);

                        if (queryUser != null)
                        {
                            usernameLabel.Text = "CMDR " + queryUser.Username;
                            emailLabel.Text = queryUser.Email;

                            Systems system = await Database.GetSystemById(queryUser.SystemId);
                            if (!(queryUser.SystemId == -1))
                            {
                                systemLabel.Text = system.Name;
                            }
                            else
                            {
                                systemLabel.Text = "Unknown";
                            }

                            infoPanel.Visible = true;
                        }
                        else
                        {
                            ShowError("This user does not exist!");
                        }
                    }
                }
                else
                {
                    Server.Transfer("Login.aspx");
                }
            }
        }

        protected async void saveButton_Click(object sender, EventArgs e)
        {
            Users user = new Users();

            user.Username = usernameEditLabel.Text;
            user.Password = passwordTextbox.Text;
            user.Email = emailTextbox.Text;

            HttpResponseMessage response = await Database.SaveUser(user);

            if (!response.IsSuccessStatusCode)
            {
                ShowError("Your details could not be saved!");
            }
        }

        private void ShowError(string errorMessage)
        {
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;
        }
    }
}