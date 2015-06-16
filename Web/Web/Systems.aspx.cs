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
                            string systemName = Request.QueryString["System"];

                            if (systemName == null)
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
                                systemTextbox.Text = systemName;
                            }

                            GetSystemData();
                        }
                        else
                        {
                            systemPanel.Visible = false;
                            ShowError("You need to be Mostly harmless to access this page!", Color.Red);
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
            GetSystemData();
        }

        private async void GetSystemData()
        {
            try
            {
                Systems system = await Database.GetSystemByName(systemTextbox.Text.Replace(".", "|"));

                if (system != null)
                {
                    labelPanel.Visible = true;

                    nameLabel.Text = system.Name;
                    populationLabel.Text = system.Population;
                
                    if (system.Allegiance == null)
                    {
                        allegianceLabel.Text = "Unknown";
                    }
                    else
                    {
                        allegianceLabel.Text = system.Allegiance;
                    }

                    if (system.Faction == null)
                    {
                        factionLabel.Text = "Unknown";
                    }
                    else
                    {
                        factionLabel.Text = system.Faction;
                    }

                    if (system.Primary_economy == null)
                    {
                        economyLabel.Text = "Unknown";
                    }
                    else
                    {
                        economyLabel.Text = system.Primary_economy;
                    }

                    if (system.State == null)
                    {
                        stateLabel.Text = "None";
                    }
                    else
                    {
                        stateLabel.Text = system.State;
                    }

                    if (system.Security == null)
                    {
                        securityLabel.Text = "Unknown";
                    }
                    else
                    {
                        securityLabel.Text = system.Security;
                    }

                    if (system.Needs_permit == "0")
                    {
                        permitLabel.Text = "No";
                    }
                    else
                    {
                        permitLabel.Text = "Yes";
                    }
                }
                else
                {
                    labelPanel.Visible = false;

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