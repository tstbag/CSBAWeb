<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="DraftPlayer.aspx.cs" Inherits="CSBANet.Draft.DraftPlayer" %>

<%@ Register Src="~/Common/WebControls/ucDraftPlayer.ascx" TagPrefix="uc1" TagName="ucDraftPlayer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <uc1:ucDraftPlayer runat="server" id="ucDraftPlayer" />


</asp:Content>
