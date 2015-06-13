using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                Server.Execute("Login.aspx");
            }
            else
            {
                GetData();
            }            
        }

        private void ShowError(string errorMessage, Color color)
        {
            errorLabel.ForeColor = color;
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;
        }

        private async void GetData()
        {
            try
            {
                Users currentUser = (Users)Session["loggedIn"];

                List<Users> users = await Database.GetUsersCloseToSystem(currentUser.SystemId, Convert.ToInt32(lightyearValueLabel.Text));

                if (users != null)
                {
                    commanderPanel.Controls.Clear();

                    foreach (Users user in users)
                    {
                        if (user.Username != currentUser.Username)
                        {
                            Systems system = await Database.GetSystemById(user.SystemId);

                            System.Web.UI.WebControls.Image rankImage = new System.Web.UI.WebControls.Image();
                            HyperLink nameLink = new HyperLink();
                            Label systemLabel = new Label();
                            Panel itemsPanel = new Panel();

                            rankImage.ImageUrl = "~/assets/ranks/" + user.Rank() + ".jpg";
                            nameLink.Text = "CMDR " + user.Username;
                            nameLink.NavigateUrl = "Userpage.aspx?Username=" + user.Username;
                            systemLabel.Text = "Last known location: " + system.Name;

                            itemsPanel.Controls.Add(rankImage);
                            itemsPanel.Controls.Add(new LiteralControl("<br />"));
                            itemsPanel.Controls.Add(nameLink);
                            itemsPanel.Controls.Add(new LiteralControl("<br />"));
                            itemsPanel.Controls.Add(systemLabel);

                            commanderPanel.Controls.Add(itemsPanel);
                        }
                    }
                }
                else
                {
                    Label infoLabel = new Label();

                    infoLabel.Text = "There are no commanders near you!";

                    commanderPanel.Controls.Add(infoLabel);
                }
            }
            catch
            {
                ShowError("There was an error getting the data!", Color.Red);
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}