<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Async="true" Inherits="Web.Login" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-user"></span>
			<h2><strong>Login</strong></h2>
            <p>
                Login to get access to your unlocked features!
            </p>
		</header>

		<section class="wrapper style1 container special">
				<div class="12u 12u(narrower)">

					<section>
                        <div>
                            <header>
								<h3>
                                    Username 
                                    <asp:RequiredFieldValidator ID="usernameVal" runat="server" ControlToValidate="usernameTextbox" Display="Dynamic" ErrorMessage="Username is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="usernameTextbox" runat="server"></asp:TextBox>
                                    <br />
                                    Password
                                    <asp:RequiredFieldValidator ID="passwordVal" runat="server" ControlToValidate="passwordTextbox" Display="Dynamic" ErrorMessage="Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="passwordTextbox" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />

                                    <asp:Panel ID="errorPanel" runat="server" Visible="False">
                                        <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                                    </asp:Panel>
                                </h3>
							</header>
                        </div>
					</section>

				</div>
		</section>
	</article>
</asp:Content>
