<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageSeasonPlayer.aspx.cs" Inherits="CSBANet.Season.ManageSeasonPlayer" %>
<%@ Register TagPrefix="uc" TagName="ucSeasonPlayer"
    Src="~/Common/WebControls/ucSeasonPlayer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <uc:ucSeasonPlayer ID="ucSeasonPlayer"
        runat="server" />

</asp:Content>
