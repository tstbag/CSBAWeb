<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CSBANet._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Welcome to CSBA!
        </h1>
        <asp:Panel ID="pnlMain" runat="server">
            <telerik:RadRotator ID="RadRotator1"
                runat="server"
                Width="100%"
                Height="590px"
                CssClass="horizontalRotator"
                ItemHeight="550px"
                ItemWidth="560px"
                Skin="<%$ appSettings:Telerik.Skin%>"
                ScrollDuration="300" EnableRandomOrder="true"
                FrameDuration="500"
                SlideShowAnimation-Type="CrossFade" 
                RotatorType="AutomaticAdvance" 
                DataSourceID="ObjectDataSource1">
                <ItemTemplate>
                    <telerik:RadBinaryImage runat="server" CropPosition="Top" ResizeMode="Crop"  ID="RadBinaryImage1" DataValue='<%#Eval("PlayerImage") %>'
                        AutoAdjustImageControlSize="false" Height="500px" Width="400px" ToolTip='<%#Eval("PlayerName", "Photo of {0}") %>'
                        AlternateText='<%#Eval("PlayerName", "Photo of {0}") %>'></telerik:RadBinaryImage>
                </ItemTemplate>
            </telerik:RadRotator>
        </asp:Panel>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListPlayers" TypeName="CSBA.BusinessLogicLayer.PlayerBusinessLogic">
            <SelectParameters>
                <asp:Parameter DefaultValue="%" Name="strLetter" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>


    
</asp:Content>
