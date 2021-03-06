﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="Web.CheckIn" MaintainScrollPositionOnPostback="true" Async="true" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">

		<header class="special container">
			<span class="icon fa fa-clock-o"></span>
			<h2><strong>Check-in</strong></h2>
            <p>
                Check-in to let others know where you are!
            </p>
		</header>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<section class="wrapper style1 container special">
				<div class="12u 12u(narrower)">

					<section>
                        <div>
                            <header>
								<h3>
                                    I am currently in this system
                                    <br />
                                    <asp:TextBox ID="systemTextbox" runat="server"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="autoCompleteExtender" runat="server" Enabled="True" TargetControlID="systemTextbox" ServiceMethod="SearchSystems" MinimumPrefixLength="1" ServicePath="~/AutoComplete.asmx" CompletionInterval="200" CompletionSetCount="20" CompletionListItemCssClass="autocomplete_listItem " CompletionListCssClass="autocomplete_completionListElement " EnableCaching="False" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                    </cc1:AutoCompleteExtender>
                                    <asp:RequiredFieldValidator ID="systemVal" runat="server" ControlToValidate="systemTextbox" Display="Dynamic" ErrorMessage="System is required!" ForeColor="Red"></asp:RequiredFieldValidator>
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
