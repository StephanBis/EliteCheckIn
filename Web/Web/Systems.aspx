<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Systems.aspx.cs" Inherits="Web.Systems1" Async="true" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-star"></span>
			<h2><strong>Systems</strong></h2>
            <p>
                Here you can get almost all details about a specific system!
            </p>
		</header>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<section class="wrapper style1 container special">
				<div class="12u 12u(narrower)">

					<section>
                        <div>
                            <header>
								<h3>
                                    <asp:Panel ID="systemPanel" runat="server">
                                        Get details for
                                        <br />
                                        <asp:TextBox ID="systemTextbox" runat="server"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="autoCompleteExtender" runat="server" Enabled="True" TargetControlID="systemTextbox" ServiceMethod="SearchSystems" MinimumPrefixLength="1" ServicePath="~/AutoComplete.asmx" CompletionInterval="200" CompletionSetCount="20" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement " EnableCaching="False" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="systemVal" runat="server" ControlToValidate="systemTextbox" Display="Dynamic" ErrorMessage="System is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Button ID="getButton" runat="server" Text="Get details" OnClick="getButton_Click" />
                                        <br />
                                        <br />
                                        <asp:Panel ID="labelPanel" runat="server">
                                            <strong><asp:Label ID="nameLabel" runat="server" Text=""></asp:Label></strong>
                                            <br />
                                            <strong>Allegiance</strong>
                                            <br />
                                            <asp:Label ID="allegianceLabel" runat="server" Text=""></asp:Label>
                                            <br />
                                            <strong>Faction</strong>
                                            <br />
                                            <asp:Label ID="factionLabel" runat="server" Text=""></asp:Label>
                                            <br />
                                            <strong>Permitted needed</strong>
                                            <br />
                                            <asp:Label ID="permitLabel" runat="server" Text=""></asp:Label>
                                            <br />
                                            <strong>Population</strong>
                                            <br />
                                            <asp:Label ID="populationLabel" runat="server" Text=""></asp:Label>
                                            <br />
                                            <strong>Primary economy</strong>
                                            <br />
                                            <asp:Label ID="economyLabel" runat="server" Text=""></asp:Label>
                                            <br />
                                            <strong>Security</strong>
                                            <br />
                                            <asp:Label ID="securityLabel" runat="server" Text=""></asp:Label>
                                            <br />
                                            <strong>State</strong>
                                            <br />
                                            <asp:Label ID="stateLabel" runat="server" Text=""></asp:Label>
                                        </asp:Panel>
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
