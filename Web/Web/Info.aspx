<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Web.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <article id="main">

		<header class="special container">
			<span class="icon fa fa-info"></span>
			<h2><strong>Info</strong></h2>
            <p>
                This is some information about our tool!
            </p>
		</header>

         <section class="wrapper style1 container special">
			<div class="12u 12u(narrower)">

				<section>
                    <div>
                        <header>
							<h3>
                                <strong>Rank system</strong>
							</h3>

                            <table style="width: 100%;">
                                <tr>
                                    <td><strong>Score</strong></td>
                                    <td><strong>Emblem</strong></td>
                                    <td><strong>Title</strong></td>
                                    <td><strong>Benefits</strong></td>
                                </tr>
                                <tr>
                                    <td>50</td>
                                    <td><asp:Image ID="Image1" runat="server" ImageUrl="~/assets/ranks/Harmless.jpg" Width="50px" /></td>
                                    <td>Harmless</td>
                                    <td>Check-in and overview</td>
                                </tr>
                                <tr>
                                    <td>100</td>
                                    <td><asp:Image ID="Image9" runat="server" ImageUrl="~/assets/ranks/Mostly harmless.jpg" Width="50px" /></td>
                                    <td>Mostly harmless</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>150</td>
                                    <td><asp:Image ID="Image2" runat="server" ImageUrl="~/assets/ranks/Novice.jpg" Width="50px" /></td>
                                    <td>Novice</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>200</td>
                                    <td><asp:Image ID="Image3" runat="server" ImageUrl="~/assets/ranks/Competent.jpg" Width="50px" /></td>
                                    <td>Competent</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>250</td>
                                    <td><asp:Image ID="Image4" runat="server" ImageUrl="~/assets/ranks/Expert.jpg" Width="50px" /></td>
                                    <td>Expert</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>300</td>
                                    <td><asp:Image ID="Image5" runat="server" ImageUrl="~/assets/ranks/Master.jpg" Width="50px" /></td>
                                    <td>Master</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>350</td>
                                    <td><asp:Image ID="Image6" runat="server" ImageUrl="~/assets/ranks/Dangerous.jpg" Width="50px" /></td>
                                    <td>Dangerous</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>400</td>
                                    <td><asp:Image ID="Image7" runat="server" ImageUrl="~/assets/ranks/Deadly.jpg" Width="50px" /></td>
                                    <td>Deadly</td>
                                    <td>N/A</td>
                                </tr>
                                <tr>
                                    <td>450</td>
                                    <td><asp:Image ID="Image8" runat="server" ImageUrl="~/assets/ranks/Elite.jpg" Width="50px" /></td>
                                    <td>Elite</td>
                                    <td>Unobtainable, only for Admins</td>
                                </tr>
                            </table>

                            <h3>
                                <strong>Updates</strong>
							</h3>

                            <table style="width: 100%;">
                                <tr>
                                    <td><strong>Update</strong></td>
                                    <td><strong>Changes</strong></td>
                                </tr>
                                <tr>
                                    <td>Beta 1.1</td>
                                    <td>
                                        + Overview page
                                        <br />
                                        + Rank system
                                        <br />
                                        + Info page
                                        <br />
                                        ~ Bugfixes
                                    </td>
                                </tr>
                                <tr>
                                    <td>Beta 1.0</td>
                                    <td>
                                        + Check-in page
                                        <br />
                                        + Userpage
                                    </td>
                                </tr>
                            </table>
						</header>
                    </div>
				</section>

			</div>
		</section>
	</article>
</asp:Content>
