<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="Web.Overview"  Async="true" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <article id="main">

		<header class="special container">
			<span class="icon fa fa-clock-o"></span>
			<h2><strong>Overview</strong></h2>
            <p>
                Check where other commanders are hanging out!
            </p>
		</header>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<section class="wrapper style1 container special">
				<div class="12u 6u(narrower)">

					<section>
                        <div>
                            <header>
								<h3>
                                    Commanders that are close to your location:
                                    <br />
                                    <asp:Label ID="lightyearLabel" runat="server" Text="LY radius:"></asp:Label>
                                    &nbsp;<asp:Label ID="lightyearValueLabel" runat="server" Text="10"></asp:Label>
                                    <asp:TextBox ID="lightyearSliderTextbox" runat="server" AutoPostBack="True"></asp:TextBox>
                                    <cc1:SliderExtender ID="lightyearSlider" runat="server" TargetControlID="lightyearSliderTextbox" Minimum="1" TooltipText="Drag to change lightyear value" BoundControlID="lightyearValueLabel" RaiseChangeOnlyOnMouseUp="False" RailCssClass="ajax__slider_h_rail centered" />
                                    <br />
                                    <asp:ListBox ID="commandersListbox" runat="server"></asp:ListBox>

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
