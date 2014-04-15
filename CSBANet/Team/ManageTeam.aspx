<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageTeam.aspx.cs" Inherits="CSBANet.Team.ManageTeam" %>
<%@ Register TagPrefix="uc" TagName="ucTeamGrid"
    Src="~/Common/WebControls/ucTeamGrid.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <uc:ucTeamGrid ID="ucTeamGrid"
        runat="server" />
</asp:Content>
