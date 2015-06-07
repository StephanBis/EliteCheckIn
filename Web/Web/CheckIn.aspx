<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="Web.CheckIn" Async="true" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-clock-o"></span>
			<h2><strong>Check-in</strong></h2>
            <p>
                Check-in to let others know where you are!
            </p>
		</header>

		<section class="wrapper style1 container special">
				<div class="12u 12u(narrower)">

					<section>
                        <div>
                            <header>
								<h3>
                                    I am currently in this system
                                    <br />
                                    <asp:DropDownList ID="systemsDropdownlist" runat="server" Width="30%" ToolTip="Click me!"></asp:DropDownList>
                                    <br />
                                    <asp:Button ID="checkInButton" runat="server" Text="Check-in" OnClick="checkInButton_Click" />

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
