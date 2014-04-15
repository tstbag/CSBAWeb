<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageStadium.aspx.cs" Inherits="CSBANet.Stadium.ManageStadium" %>

<%@ Register TagPrefix="uc" TagName="ucStadium"
    Src="~/Common/WebControls/ucStadium.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ucStadium ID="ucStadium"
        runat="server" />
</asp:Content>
