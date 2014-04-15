<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageSeasonStadium.aspx.cs" Inherits="CSBANet.Season.ManageSeasonStadium" %>

<%@ Register TagPrefix="uc" TagName="ucSeasonStadium"
    Src="~/Common/WebControls/ucSeasonStadium.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <uc:ucSeasonStadium ID="ucSeasonStadium"
        runat="server" />
</asp:Content>
