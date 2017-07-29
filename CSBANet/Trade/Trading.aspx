<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Trading.aspx.cs" Inherits="CSBANet.Trade.Trading" %>

<%@ Register Src="~/Common/WebControls/ucTrade.ascx" TagPrefix="uc1" TagName="ucTrade" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .inlineBlock {
            display: inline-block;
        }
    </style>
    <style type="text/css">
        .floatLeft {
            float: left;
            margin-right: 20px;
            height: 600px;
        }
    </style>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
<%--        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rDDMyPositionType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rDDMyPositionType"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDLMyTeam"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDZMyTeam"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rDDSeasonTeam">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rDDSeasonTeam"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDDOtherPositionType"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDLOtherTeam"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDZOtherTeam"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rDDOtherPositionType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rDDOtherPositionType"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDLOtherTeam"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rDZOtherTeam"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>--%>

    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="25">
    </telerik:RadAjaxLoadingPanel>

    <telerik:RadDropDownList ID="rDDSeason" runat="server" OnSelectedIndexChanged="rDDSeason_SelectedIndexChanged" AutoPostBack="true">
    </telerik:RadDropDownList>

    <asp:Panel ID="pnlOuter" runat="server" Width="100%" CssClass="floatLeft">
        <asp:Panel ID="pnlMyTeam" runat="server" Width="30%"
            BorderWidth="1px" BorderStyle="Solid" BorderColor="Red"
            CssClass="floatLeft">
            <asp:Label ID="lblMyTeam" Text="My Team" runat="server"></asp:Label>
            <br />
            <telerik:RadDropDownList ID="rDDMyPositionType" runat="server"
                OnSelectedIndexChanged="rDDMyPositionType_SelectedIndexChanged"
                AutoPostBack="true">
            </telerik:RadDropDownList>
            <br />
            <div class="demo-container size-wide">

                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                    OnAjaxRequest="RadAjaxPanel1_AjaxRequest">
                    <telerik:RadDockLayout
                        runat="server"
                        ID="rDLMyTeam"
                        EnableLayoutPersistence="true"
                        LayoutPersistenceRepositoryType="Cookies"
                        LayoutRepositoryID="DockLayout">
                    </telerik:RadDockLayout>

                    <telerik:RadDockZone runat="server" ID="rDZMyTeam" Orientation="Horizontal"
                        Width="95%" Height="500">
                    </telerik:RadDockZone>


                </telerik:RadAjaxPanel>


            </div>
        </asp:Panel>

        <asp:Panel ID="pnlTrade" runat="server" Width="30%"
            BorderWidth="1px" BorderStyle="Solid" BorderColor="Green"
            CssClass="floatLeft">
            <asp:Label ID="Label1" Text="Trade" runat="server"></asp:Label>

            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
                OnAjaxRequest="RadAjaxPanel2_AjaxRequest" Width="640px">

                <telerik:RadDockLayout
                    runat="server"
                    ID="rDLTradeArea"
                    EnableLayoutPersistence="true"
                    LayoutPersistenceRepositoryType="Cookies"
                    LayoutRepositoryID="DockLayout">
                </telerik:RadDockLayout>

                <telerik:RadDockZone runat="server" ID="rDZTradeZone" Orientation="Horizontal"
                    Width="95%" Height="500">
                </telerik:RadDockZone>

            </telerik:RadAjaxPanel>

        </asp:Panel>

        <asp:Panel ID="pnlOtherTeam" runat="server" Width="30%"
            BorderWidth="1px" BorderStyle="Solid" BorderColor="Blue"
            CssClass="floatLeft">

            <asp:Table ID="tblParms" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="30%">
                        <asp:Label ID="lblTeam" runat="server" Text="Team:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="65%">
                        <telerik:RadDropDownList ID="rDDSeasonTeam"
                            Skin="<%$ appSettings:Telerik.Skin%>"
                            DropDownHeight="100px" AutoPostBack="true"
                            OnSelectedIndexChanged="rDDSeason_SelectedIndexChanged"
                            runat="server">
                        </telerik:RadDropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Width="30%">
                        <asp:Label ID="lblPosition" runat="server" Text="Position Type:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="65%">
                        <telerik:RadDropDownList ID="rDDOtherPositionType"
                            runat="server"
                            OnSelectedIndexChanged="rDDOtherPositionType_SelectedIndexChanged"
                            AutoPostBack="true">
                        </telerik:RadDropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <telerik:RadDockLayout
                runat="server"
                ID="rDLOtherTeam"
                EnableLayoutPersistence="true"
                LayoutPersistenceRepositoryType="Cookies"
                LayoutRepositoryID="DockLayout">
            </telerik:RadDockLayout>

            <telerik:RadDockZone runat="server" ID="rDZOtherTeam" Orientation="Horizontal"
                Width="95%" Height="500">
            </telerik:RadDockZone>

        </asp:Panel>
    </asp:Panel>

</asp:Content>
