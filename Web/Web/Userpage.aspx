<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Userpage.aspx.cs" Inherits="Web.Userpage" Async="true" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-user"></span>
			<h2><strong>Userpage</strong></h2>
            <p>
                Here you have the details of the user!
            </p>
		</header>

		<section class="wrapper style1 container special">
				<div class="12u 12u(narrower)">

					<section>
                        <div>
                            <header>
                                <h3>


                                    <asp:Image ID="rankImage" runat="server" />


                                    <asp:Panel ID="editPanel" runat="server" Visible="False">
                                        <strong>Username</strong>
                                        <br /> 
                                        <asp:Label ID="usernameEditLabel" runat="server" Text=""></asp:Label>
                                        <br />
                                        <br />
                                        <strong>Password</strong>
                                        <asp:RequiredFieldValidator ID="passwordVal" runat="server" ControlToValidate="passwordTextbox" Display="Dynamic" ErrorMessage="Password is required!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        &nbsp;<asp:TextBox ID="passwordTextbox" runat="server" TextMode="Password"></asp:TextBox>
                                        <br />
                                        <strong>Confirm password</strong>
                                        <asp:CompareValidator ID="compareVal" runat="server" ControlToCompare="passwordTextbox" ControlToValidate="password2Textbox" Display="Dynamic" ErrorMessage="Passwords do not match!" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="password2Val" runat="server" ControlToValidate="password2Textbox" Display="Dynamic" ErrorMessage="Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        &nbsp;<asp:TextBox ID="password2Textbox" runat="server" TextMode="Password"></asp:TextBox>
                                        <br />
                                        <strong>E-mail</strong>
                                        <asp:RequiredFieldValidator ID="emailVal" runat="server" ControlToValidate="emailTextbox" Display="Dynamic" ErrorMessage="E-mail is required!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        &nbsp;<asp:TextBox ID="emailTextbox" runat="server" TextMode="Email"></asp:TextBox>
                                        <br />
                                        <strong>Last known location</strong>
                                        <br />
                                        <asp:HyperLink ID="systemLink" runat="server"><asp:Label ID="systemEditLabel" runat="server" Text=""></asp:Label></asp:HyperLink>
                                        <br />
                                        <br />
                                        <asp:Button ID="saveButton" runat="server" Text="Save changes" OnClick="saveButton_Click" />
                                    </asp:Panel>
								
                                   <asp:Panel ID="infoPanel" runat="server" Visible="False">
                                        <strong>Username</strong>
                                        <br />
                                        <asp:Label ID="usernameLabel" runat="server" Text=""></asp:Label>
                                        <br />
                                        <strong>Last known location</strong>
                                        <br />
                                        <asp:Label ID="systemLabel" runat="server" Text=""></asp:Label>
                                    </asp:Panel>

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
