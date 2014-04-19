<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeasonStadium.ascx.cs" Inherits="CSBANet.Common.WebControls.ucSeasonStadium" %>

<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function OnClientFilesUploaded(sender, args) {
            $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
        }
    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rDDSeason">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rGridSeason"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rGridSeason">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rGridSeason"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>

</telerik:RadAjaxManager>

<asp:Panel ID="pnlSeasonStadium" runat="server" Width="70%">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSeason" runat="server" Text="Season"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadDropDownList ID="rDDSeason" runat="server" OnSelectedIndexChanged="rDDSeason_SelectedIndexChanged" AutoPostBack="true">
                </telerik:RadDropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFromBox" runat="server" Text="Remaining Stadiums"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblToBox" runat="server" Text="Selected Stadiums"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow>           
            <asp:TableCell>
                <telerik:RadListBox runat="server"
                    ID="rLBStadiumRemaining"
                    Height="200px"
                    Width="200px"
                    AllowTransfer="true"
                    TransferToID="rLBStadiumSelected">
                </telerik:RadListBox>
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadListBox runat="server"
                    ID="rLBStadiumSelected"
                    Height="200px"
                    AllowReorder="true"
                    Width="200px">
                </telerik:RadListBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <telerik:RadButton ID="rBTNSaveChanges" runat="server" ButtonType="SkinnedButton" Text="Save" OnClick="rBTNSaveChanges_Click"></telerik:RadButton>
                &nbsp;
                <telerik:RadButton ID="rBTNCancel" runat="server" ButtonType="SkinnedButton" Text="Cancel" OnClick="rBTNCancel_Click"></telerik:RadButton>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Panel>
