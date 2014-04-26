<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CSBANet.Account.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

            <h1>Reset Password</h1>

            <asp:Label ID="Msg" runat="server" ForeColor="maroon" /><br />

            Username:
            <asp:TextBox ID="UsernameTextBox" Columns="30" runat="server" AutoPostBack="true" />
            <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server"
                ControlToValidate="UsernameTextBox" ForeColor="red"
                Display="Static" ErrorMessage="Required" /><br />

            <asp:Button ID="ResetPasswordButton" Text="Reset Password"
                OnClick="ResetPassword_OnClick" runat="server" Enabled="false" />


</asp:Content>
