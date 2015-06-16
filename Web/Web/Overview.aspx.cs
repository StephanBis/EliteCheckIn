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
            Session["page"] = "Overview.aspx";

            if (Session["loggedIn"] == null)
            {
                Server.Execute("Login.aspx");
            }
            else
            {
                lightyearValueLabel.Text = lightyearSlider.Value.ToString();

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
                int value = (int)lightyearSlider.Value;

                Users currentUser = (Users)Session["loggedIn"];

                List<Users> users = await Database.GetUsersCloseToSystem(currentUser.SystemId, value);

                ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                Control c = myContent.FindControl("commandersDiv");
                c.Controls.Clear();

                if (users != null && users.Count != 1)
                {
                    foreach (Users user in users)
                    {
                        if (user.Username != currentUser.Username)
                        {
                            Systems system = await Database.GetSystemById(user.SystemId);

                            LiteralControl literal = new LiteralControl("<div class='4u 12u(narrower)'><section> <img src='assets/ranks/" + user.Rank() + ".jpg' /> <div><header><h3> <a href='Userpage.aspx?Username=" + user.Username + "'>CMDR " + user.Username + "</a> </h3></header><p>Last known location: <a href='Systems.aspx?System=" + system.Name + "'>" + system.Name + "</a></p></div></section></div>");

                            c.Controls.Add(literal);
                        }
                    }
                }
                else
                {
                    LiteralControl literal = new LiteralControl("<div class='12u 2u(narrower)'><section><div><header><h3>There are no commanders in the specified range!</h3></header></div></section></div>");

                    c.Controls.Add(literal);
                }
            }
            catch
            {
                ShowError("There was an error getting the data!", Color.Red);
            }
        }
    }
}