<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="Web.Overview"  Async="true" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadScriptManager ID="ScriptManager1" runat="server" EnableTheming="True">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>

    <script>
        function clientValueChange(sender, eventArgs) {
            document.body.style.cursor = 'wait';

            var myDiv = document.getElementById("MainContent_lightyearValueLabel")
            myDiv.innerHTML = sender.get_value();

            var slider = document.getElementById("RadSliderWrapper_ctl00_MainContent_lightyearSlider")
            slider.style.removeProperty("width");
        }
    </script>

     <article id="main">

		<header class="special container">
			<span class="icon fa fa-bars"></span>
			<h2><strong>Overview</strong></h2>
            <p>
                Check where other commanders are hanging out!
            </p>
		</header>
		<section class="wrapper style1 container special">           
			<div class="12u 2u(narrower)">
				<section>
                    <div>
                        <header>
							<h3>
                                Commanders that are in range
                                <br />
                                <asp:Label ID="lightyearLabel" runat="server" Text="LY radius:"></asp:Label>
                                &nbsp;<asp:Label ID="lightyearValueLabel" runat="server" Text="10"></asp:Label>
                                <telerik:RadSlider ID="lightyearSlider" runat="server" DbValue="0" Height="22px" Length="200" CssClass="centered" SelectionEnd="100" SelectionStart="1" Value="10" MinimumValue="1" RenderMode="Auto" OnClientValueChanged="clientValueChange" AutoPostBack="True" DecreaseText="-1 LY" DragText="Drag to change LY" IncreaseText="+1 LY">
                            </telerik:RadSlider>
                                <br />                                    
                                <asp:Panel ID="errorPanel" runat="server" Visible="False">
                                    <asp:Label ID="errorLabel" runat="server" ForeColor="Red"></asp:Label>
                                </asp:Panel>
                            </h3>
						</header>
                    </div>
				</section>
            </div>

            <div runat="server" id="commandersDiv" class="row">

            </div>
		</section>
	</article>
</asp:Content>
