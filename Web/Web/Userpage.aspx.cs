using System;
using System.Collections.Generic;
using System.Drawing;
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
                    try
                    {
                        Users user = (Users)Session["loggedIn"];
                        string username = Request.QueryString["Username"];

                        if (username.ToLower() == user.Username.ToLower())
                        {
                            usernameEditLabel.Text = "CMDR " + user.Username;
                            passwordTextbox.Text = user.Password;
                            emailTextbox.Text = user.Email;
                            rankImage.ImageUrl = "~/assets/ranks/" + user.Rank() + ".jpg";
                            rankImage.ToolTip = "Rank: " + user.Rank();

                            Systems system = await Database.GetSystemById(user.SystemId);
                            if (!(user.SystemId <= 0))
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
                                rankImage.ImageUrl = "~/assets/ranks/" + queryUser.Rank() + ".jpg";
                                rankImage.ToolTip = "Rank: " + queryUser.Rank();

                                Systems system = await Database.GetSystemById(queryUser.SystemId);
                                if (!(queryUser.SystemId <= 0))
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
                                ShowError("This user does not exist!", Color.Red);
                            }
                        }
                    }
                    catch
                    {
                        ShowError("There was an error getting the data!", Color.Red);
                    }
                }
                else
                {
                    Server.Execute("Login.aspx");
                }
            }
        }

        protected async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = new Users();

                user.Username = usernameEditLabel.Text;
                user.Password = passwordTextbox.Text;
                user.Email = emailTextbox.Text;

                HttpResponseMessage response = await Database.SaveUser(user);

                if (!response.IsSuccessStatusCode)
                {
                    ShowError("Your details could not be saved!", Color.Red);
                }
                else
                {
                    ShowError("Your details have been saved!", Color.Green);
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