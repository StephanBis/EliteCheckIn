<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Async="true" Inherits="Web.Register" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-user-plus"></span>
			<h2><strong>Register</strong></h2>
            <p>
                Register to get access to the website!
            </p>
		</header>

		<section class="wrapper style1 container special">
				<div class="12u 12u(narrower)">

					<section>
                        <div>
                            <header>
								<h3>
                                    Username 
                                    <asp:RequiredFieldValidator ID="usernameVal" runat="server" ControlToValidate="usernameTextbox" Display="Dynamic" ErrorMessage="Username is required!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="usernameTextbox" runat="server"></asp:TextBox>
                                    <br />
                                    Password
                                    <asp:RequiredFieldValidator ID="passwordVal" runat="server" ControlToValidate="passwordTextbox" Display="Dynamic" ErrorMessage="Password is required!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="passwordTextbox" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    Confirm password
                                    <asp:CompareValidator ID="compareVal" runat="server" ControlToCompare="passwordTextbox" ControlToValidate="password2Textbox" Display="Dynamic" ErrorMessage="Passwords do not match!" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="password2Val" runat="server" ControlToValidate="password2Textbox" Display="Dynamic" ErrorMessage="Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="password2Textbox" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    E-mail
                                    <asp:RequiredFieldValidator ID="emailVal" runat="server" ControlToValidate="emailTextbox" Display="Dynamic" ErrorMessage="E-mail is required!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:TextBox ID="emailTextbox" runat="server" TextMode="Email"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click" />

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
