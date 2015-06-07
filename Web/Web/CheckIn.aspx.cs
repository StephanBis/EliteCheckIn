using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class CheckIn : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    List<Systems> systems = await Database.GetSystems();

                    systemsDropdownlist.DataTextField = "Name";
                    systemsDropdownlist.DataValueField = "Id";
                    systemsDropdownlist.DataSource = systems;
                    systemsDropdownlist.DataBind();

                    Users user = (Users)Session["loggedIn"];

                    if (!(user.SystemId == -1))
                    {
                        systemsDropdownlist.SelectedValue = user.SystemId.ToString();
                    }
                }
            }
        }

        protected async void checkInButton_Click(object sender, EventArgs e)
        {
            Users user = (Users)Session["loggedIn"];
            user.SystemId = Convert.ToInt32(systemsDropdownlist.SelectedValue);

            HttpResponseMessage response = await Database.SaveUser(user);

            if (!response.IsSuccessStatusCode)
            {
                ShowError("Unable to check-in!");
            }
        }

        private void ShowError(string errorMessage)
        {
            errorLabel.Text = errorMessage;
            errorPanel.Visible = true;
        }
    }
}