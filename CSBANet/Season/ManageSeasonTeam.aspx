<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageSeasonTeam.aspx.cs" Inherits="CSBANet.Season.ManageSeasonTeam" %>
<%@ Register TagPrefix="uc" TagName="ucSeasonTeamOrder"
    Src="~/Common/WebControls/ucSeasonTeamOrder.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    
    <uc:ucSeasonTeamOrder ID="ucSeason"
        runat="server" />
</asp:Content>
