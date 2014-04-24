<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="PlayerStats.aspx.cs" Inherits="CSBANet.Player.PlayerStats" %>

<%@ Register Src="~/Common/WebControls/ucPlayerStats.ascx" TagPrefix="uc1" TagName="ucPlayerStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hddSeasonID" runat="server" Value="0" />
    <asp:HiddenField ID="hddPlayerGUID" runat="server" Value="00000000-0000-0000-0000-000000000000" />
    <asp:HiddenField ID="hddPrimPosID" runat="server" Value="1" />

    <asp:Panel ID="pnlOptions" runat="server">
        <asp:Table runat="server" Width="50%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSeason" runat="server" Text="Season: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="rDDSeason"
                        runat="server"
                        Skin="<%$ appSettings:Telerik.Skin%>"
                        OnSelectedIndexChanged="rDDSeason_SelectedIndexChanged"
                        AutoPostBack="true">
                    </telerik:RadDropDownList>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="lblPositionType" runat="server" Text="Position Type: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="rDDPositionType"
                        runat="server"
                        Skin="<%$ appSettings:Telerik.Skin%>"
                        OnSelectedIndexChanged="rDDPositionType_SelectedIndexChanged"
                        AutoPostBack="true">
                    </telerik:RadDropDownList>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>


    </asp:Panel>
    <uc1:ucPlayerStats runat="server" ID="ucPlayerStats" />
</asp:Content>
