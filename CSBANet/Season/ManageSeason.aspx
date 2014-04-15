<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageSeason.aspx.cs" Inherits="CSBANet.Season.ManageSeason" %>

<%@ Register TagPrefix="uc" TagName="ucSeason"
    Src="~/Common/WebControls/ucSeason.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <uc:ucSeason ID="ucSeason"
        runat="server" />
</asp:Content>
