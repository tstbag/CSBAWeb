<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDraftPlayer.ascx.cs" Inherits="CSBANet.Common.WebControls.ucDraftPlayer" %>

<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function OnClientFilesUploaded(sender, args) {
            $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
        }
    </script>
</telerik:RadScriptBlock>


<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rNTBCurrBid">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rNTBCurrBid"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="rDDSeasonTeam" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="rGridDraftPlayer" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>

    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rDDSeason">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rDDSeason"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="rDDSeasonTeam" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="rGridDraftPlayer" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>

    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rGridDraftPlayer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rGridDraftPlayer"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>


<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="25">
</telerik:RadAjaxLoadingPanel>

<asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblSeason" runat="server" Text="Season"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDropDownList ID="rDDSeason"
                runat="server"
                Skin="<%$ appSettings:Telerik.Skin%>"
                OnSelectedIndexChanged="rDDSeason_SelectedIndexChanged"
                AutoPostBack="true">
            </telerik:RadDropDownList>
        </asp:TableCell>

    </asp:TableRow>
</asp:Table>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </ContentTemplate>--%>
<%--</asp:UpdatePanel>--%>
<asp:Panel ID="pnlDraftPlayer" runat="server" Height="465px" BorderWidth="2px">

    <div style="float: left; padding-left: 5px;">
        <asp:Table ID="tblTest" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="150px" ColumnSpan="2">
                    <asp:HiddenField ID="hddPlayerGUID" runat="server" />
                    <asp:Label ID="lblCurrPlayer" runat="server" Text="PlayerName"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadBinaryImage ID="imgPlayer" runat="server" AutoAdjustImageControlSize="false" Width="160px" Height="170px" AlternateText="Player Image" />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadBinaryImage ID="imgPositon" runat="server" AutoAdjustImageControlSize="false" Width="160px" Height="170px" AlternateText="Position Image"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBidPoints" runat="server" Text="Current Bid"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>

                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadButton ID="rBTNAssign" runat="server" Text="Assign" OnClick="rBTNAssign_Click" ButtonType="SkinnedButton"></telerik:RadButton>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadDropDownList ID="rDDSeasonTeam" OnItemDataBound="rDDSeasonTeam_ItemDataBound" DropDownHeight="100px" runat="server">
                    </telerik:RadDropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <telerik:RadButton ID="rBTNPickPlayer" runat="server" Text="Pick Player" OnClick="rBTNPickPlayer_Click" ButtonType="SkinnedButton"></telerik:RadButton>
                </asp:TableCell>
                <asp:TableCell>

                    <telerik:RadNumericTextBox ID="rNTBCurrBid" OnTextChanged="rNTBCurrBid_TextChanged" Width="60px" ShowSpinButtons="true" AutoPostBack="true" NumberFormat-DecimalDigits="0" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MinBid") %>'>
                    </telerik:RadNumericTextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <div style="float: right; padding-left: 0px;">
        <telerik:RadGrid ID="rGridDraftPlayer"
            runat="server"
            OnNeedDataSource="rGridDraftPlayer_NeedDataSource"
            OnItemDataBound="rGridDraftPlayer_ItemDataBound"
            OnItemCommand="rGridDraftPlayer_ItemCommand"
            AutoGenerateColumns="False"
            BorderWidth="4px"
            AllowFilteringByColumn="True"
            AllowSorting="True"
            Skin="<%$ appSettings:Telerik.Skin%>"
            CellSpacing="0"
            GridLines="None"
            AllowMultiRowEdit="True"
            AllowMultiRowSelection="True">
            <PagerStyle />
            <ClientSettings EnablePostBackOnRowClick="true">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                BorderWidth="1px" />
            <GroupingSettings CaseSensitive="False" />
            <MasterTableView DataKeyNames="SeasonID, TeamID"
                CommandItemDisplay="None" AllowSorting="true"
                EditMode="InPlace"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Season ID" Visible="false" DataField="SeasonID" UniqueName="SeasonID">
                        <ItemTemplate>
                            <asp:Label ID="lblSeasonID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team ID" Visible="false" DataField="TeamID" UniqueName="TeamID">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.TeamID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" SortExpression="TeamName" HeaderText="Team Name" DataField="TeamName" UniqueName="TeamName">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" SortExpression="SumPoints" HeaderStyle-Width="50px" HeaderText="Points Spent" DataField="SumPoints" UniqueName="SumPoints">
                        <ItemTemplate>
                            <asp:Label ID="lblSumPoints" Width="50px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SumPoints") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" SortExpression="MaxBid" HeaderText="Max Bid" DataField="MaxBid" UniqueName="MaxBid">
                        <ItemTemplate>
                            <asp:Label ID="lblMaxBid" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaxBid") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="# Hitters" HeaderStyle-Width="50px" DataField="CountHitter" UniqueName="CountHitter">
                        <ItemTemplate>
                            <asp:Label ID="lblCountHitter" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.CountHitter") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="# Pitchers" DataField="PitcherCount" UniqueName="PitcherCount">
                        <ItemTemplate>
                            <asp:Label ID="lblPitcherCount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PitcherCount") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>


    <asp:Label ID="lblMessage" runat="server">

    </asp:Label>
</asp:Panel>
