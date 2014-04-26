<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManagePosition.aspx.cs" Inherits="CSBANet.Position.ManagePosition" %>

<%@ Register Src="~/Common/WebControls/ucPosition.ascx" TagPrefix="uc1" TagName="ucPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucPosition runat="server" id="ucPosition" />
</asp:Content>
