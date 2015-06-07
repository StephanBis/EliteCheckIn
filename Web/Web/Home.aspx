<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web.Index" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-space-shuttle"></span>
			<h2><strong>About the check-in tool</strong></h2>
            <p>
                Sometimes you just want to play in a wing with a couple of others. 
                <br />
                But it's hard as you may have noticed, you won't meet alot of other commanders out there. 
                <br />
                So we created a tool which commanders can check-in on their location!
                <br />
                <br />
                It's quite easy, just register and start checking in! 
                <br />
            </p>
		</header>

		<section class="wrapper style1 container special">
			<div class="row">
				<div class="4u 12u(narrower)">
					<section>
						<span class="icon featured fa fa-user-plus"></span>
                            <div>
                                <header>
									<h3>Register!</h3>
								</header>
								<p>Create an account to get access!</p>
                            </div>
					</section>

				</div>
				<div class="4u 12u(narrower)">

					<section>
						<span class="icon featured fa fa-plus"></span>
                            <div>
                                <header>
									<h3>Rank up!</h3>
								</header>
								<p>Adding and verifying systems/stations will grant you more features!</p>
                            </div>
					</section>

				</div>
				<div class="4u 12u(narrower)">

					<section>
						<span class="icon featured fa fa-thumbs-up"></span>
                            <div>
                                <header>
									<h3>Find other commanders!</h3>
								</header>
								<p>Use the tool to find other commanders and have fun together!</p>
                            </div>
					</section>       
				</div>
			</div>
		</section>
	</article>
</asp:Content>

