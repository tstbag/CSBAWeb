<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Trading.aspx.cs" Inherits="CSBANet.Trade.Trading" %>

<%@ Register Src="~/Common/WebControls/ucTrade.ascx" TagPrefix="uc1" TagName="ucTrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucTrade runat="server" id="ucTrade" />
</asp:Content>
