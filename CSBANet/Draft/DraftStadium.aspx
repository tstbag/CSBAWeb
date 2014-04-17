<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="DraftStadium.aspx.cs" Inherits="CSBANet.Draft.DraftStadium" %>

<%@ Register TagPrefix="uc" TagName="ucDraftStadium"
    Src="~/Common/WebControls/ucDraftStadium.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ucDraftStadium ID="ucDraftStadium"
        runat="server" />
</asp:Content>
