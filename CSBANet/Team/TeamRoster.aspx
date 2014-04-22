<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="TeamRoster.aspx.cs" Inherits="CSBANet.Team.TeamRoster" %>

<%@ Register Src="~/Common/WebControls/ucTeamRoster.ascx" TagPrefix="uc1" TagName="ucTeamRoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucTeamRoster runat="server" ID="ucTeamRoster" />
</asp:Content>
