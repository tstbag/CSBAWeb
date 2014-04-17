<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManagePlayer.aspx.cs" Inherits="CSBANet.Player.ManagePlayer" %>

<%@ Register TagPrefix="uc" TagName="ucPlayerGrid"
    Src="~/Common/WebControls/ucPlayerGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ucPlayerGrid ID="ucPlayerGrid"
        runat="server" />
</asp:Content>




