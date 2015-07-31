<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDraftPlayer.ascx.cs" Inherits="CSBANet.Common.WebControls.ucDraftPlayer" %>
<%@ Register Src="~/Common/WebControls/ucPlayerStats.ascx" TagPrefix="uc1" TagName="ucPlayerStats" %>


<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function OnClientFilesUploaded(sender, args) {
            $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
        }
    </script>
    <script type="text/javascript">
        function onToolBarClientButtonClicking(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() == "EmailRosters") {
                args.set_cancel(!confirm('Email the owners the current rosters?'));
            }
        }
    </script>
</telerik:RadScriptBlock>


<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">

    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="Timer1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rNTBCurrBid"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="rDDSeasonTeam" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="rGridDraftPlayer" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>

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
        <telerik:AjaxSetting AjaxControlID="chkDrafted_CheckedChanged">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rGridDraftPositionStatus" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>


</telerik:RadAjaxManager>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="25">
</telerik:RadAjaxLoadingPanel>

<asp:Table ID="Table1" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblSeason" runat="server" CssClass="MediumLabels" Width="100px" Text="Season"></asp:Label>
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
            <telerik:RadButton ID="rBTNEmptyRecycleBin" ButtonType="SkinnedButton" Skin="<%$ appSettings:Telerik.Skin%>" Text="Empty Recycle Bin" runat="server" OnClick="rBTNEmptyRecycleBin_Click"></telerik:RadButton>
        </asp:TableCell>

    </asp:TableRow>
</asp:Table>

<asp:Panel ID="pnlDraftPlayer" runat="server" Height="455px">
    <div style="float: left; padding-left: 5px; width: 47%; height: 100%;">
        <asp:Table ID="tblTest" runat="server" Width="100%" Height="100%">
            <asp:TableRow>
                <asp:TableCell Width="100%" ColumnSpan="2">
                    <asp:HiddenField ID="hddSeasonID" runat="server" />
                    <asp:HiddenField ID="hddPlayerGUID" runat="server" />
                    <asp:HiddenField ID="hddPrimPosID" runat="server" />
                    <asp:Label ID="lblCurrPlayer" runat="server" Text="Player Name" Width="100%" Visible="false" CssClass="LargerLabels"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="50%">
                    <telerik:RadBinaryImage ID="imgPlayer" Visible="false" runat="server" Skin="<%$ appSettings:Telerik.Skin%>" AutoAdjustImageControlSize="false" Width="250px" Height="320px" AlternateText="Player Image" />
                </asp:TableCell>
                <asp:TableCell Width="50%">
                    <telerik:RadBinaryImage ID="imgPositon" Visible="false" runat="server" Skin="<%$ appSettings:Telerik.Skin%>" CssClass="imgAdjust" AutoAdjustImageControlSize="false" Width="125px" Height="125px" AlternateText="Position Image" />
                    <div style="float: left; padding-left: 0px; width: 100%;">
                        <telerik:RadLinearGauge runat="server" Scale-Vertical="false" ID="rLGStatus" Width="250px" Height="100%">
                            <Pointer Shape="Arrow" Value="15">
                                <Track Opacity="0.2" />
                            </Pointer>
                            <Scale Min="0" Max="500" MajorUnit="50">
                                <Ranges>
                                    <telerik:GaugeRange Color="#2a94cb" From="0" To="50" />
                                    <telerik:GaugeRange Color="#8dcb2a " From="51" To="100" />
                                    <telerik:GaugeRange Color="#ffc700" From="101" To="150" />
                                    <telerik:GaugeRange Color="#ff7a00" From="151" To="200" />
                                    <telerik:GaugeRange Color="#c20000" From="201" To="250" />
                                </Ranges>
                            </Scale>
                        </telerik:RadLinearGauge>
                    </div>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="50%">
                    <telerik:RadButton ID="rBTNAssign" runat="server" Enabled="false" Skin="<%$ appSettings:Telerik.Skin%>" Width="75px" Text="Assign" CssClass="MediumLabels" OnClick="rBTNAssign_Click" ButtonType="SkinnedButton"></telerik:RadButton>
                </asp:TableCell>
                <asp:TableCell Width="50%">

                    <telerik:RadDropDownList ID="rDDSeasonTeam" OnItemDataBound="rDDSeasonTeam_ItemDataBound" Skin="<%$ appSettings:Telerik.Skin%>" DropDownHeight="100px" runat="server">
                    </telerik:RadDropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="50%">
                <asp:TableCell>
                    <telerik:RadButton ID="rBTNPickPlayer" runat="server" Width="75px" CssClass="MediumLabels" Text="Pick Player" OnClick="rBTNPickPlayer_Click" ButtonType="SkinnedButton"></telerik:RadButton>
                </asp:TableCell>
                <asp:TableCell Width="50%">
                    <telerik:RadNumericTextBox ID="rNTBCurrBid" OnTextChanged="rNTBCurrBid_TextChanged" CssClass="MediumLabels" Width="60px" ShowSpinButtons="true" AutoPostBack="true" NumberFormat-DecimalDigits="0" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MinBid") %>'>
                    </telerik:RadNumericTextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <div style="float: right; padding-left: 0px; width: 50%;">

        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" Width="100%"
            MultiPageID="RadMultiPage1" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab Text="Draft Status" Width="33%"></telerik:RadTab>
                <telerik:RadTab Text="Positions" Width="33%"></telerik:RadTab>
                <telerik:RadTab Text="Players Left" Width="33%"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>

        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">


                <telerik:RadGrid ID="rGridDraftPlayer"
                    runat="server"
                    OnNeedDataSource="rGridDraftPlayer_NeedDataSource"
                    OnItemDataBound="rGridDraftPlayer_ItemDataBound"
                    OnItemCommand="rGridDraftPlayer_ItemCommand"
                    AutoGenerateColumns="False"
                    AllowFilteringByColumn="False"
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
                        CommandItemDisplay="Top" AllowSorting="true"
                        EditMode="InPlace"
                        EnableHeaderContextAggregatesMenu="True"
                        EnableHeaderContextFilterMenu="True"
                        EnableHeaderContextMenu="True">
                        <CommandItemTemplate>
                            <telerik:RadToolBar ID="RadToolBar1" runat="server" OnClientButtonClicking="onToolBarClientButtonClicking"
                                AutoPostBack="true">
                                <Items>
                                    <telerik:RadToolBarButton Text="Email Rosters" CommandName="EmailRosters">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </CommandItemTemplate>
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

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="OwnerEmail" Visible="false" DataField="OwnerEmail" UniqueName="OwnerEmail">
                                <ItemTemplate>
                                    <asp:Label ID="lblOwnerEmail" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerEmail") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderStyle-Width="100px" SortExpression="TeamName" HeaderText="Team Name" DataField="TeamName" UniqueName="TeamName">
                                <ItemTemplate>
                                    <telerik:RadButton ID="rBTNTeamName" ButtonType="LinkButton" Width="100%" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.TeamID") %>' OnClick="rBTNTeamName_Click" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName") %>'>
                                    </telerik:RadButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" SortExpression="SumPoints" HeaderStyle-Width="50px" HeaderText="Pnt Spent" DataField="SumPoints" UniqueName="SumPoints">
                                <ItemTemplate>
                                    <asp:Label ID="lblSumPoints" Width="50px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SumPoints") %>'>
                            </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" SortExpression="MaxBid" HeaderText="Max Bid" HeaderStyle-Width="50px" DataField="MaxBid" UniqueName="MaxBid">
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

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="# Pitchers" DataField="PitcherCount" HeaderStyle-Width="50px" UniqueName="PitcherCount">
                                <ItemTemplate>
                                    <asp:Label ID="lblPitcherCount" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container, "DataItem.PitcherCount") %>'>
                            </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="rPageDraftPlayerStatus">
                <asp:CheckBox ID="chkDrafted" runat="server" Font-Bold="false" CssClass="chkBox" Width="200px" Text="Drafted" AutoPostBack="true" OnCheckedChanged="chkDrafted_CheckedChanged" />

                <telerik:RadGrid ID="rGridDraftPositionStatus"
                    runat="server"
                    OnNeedDataSource="rGridDraftPositionStatus_NeedDataSource"
                    AutoGenerateColumns="False"
                    AllowFilteringByColumn="False"
                    AllowSorting="True"
                    Skin="<%$ appSettings:Telerik.Skin%>"
                    CellSpacing="0"
                    GridLines="None"
                    AllowMultiRowEdit="False"
                    AllowMultiRowSelection="False">
                    <PagerStyle />
                    <ClientSettings EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                        BorderWidth="1px" />
                    <GroupingSettings CaseSensitive="False" />
                    <MasterTableView DataKeyNames="SeasonID, PositionName, Drafted"
                        CommandItemDisplay="None"
                        AllowSorting="True"
                        EditMode="InPlace"
                        EnableHeaderContextAggregatesMenu="False"
                        EnableHeaderContextFilterMenu="False"
                        EnableHeaderContextMenu="False">
                        <Columns>

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Season ID" Visible="false" DataField="SeasonID" UniqueName="SeasonID">
                                <ItemTemplate>
                                    <asp:Label ID="lblSeasonID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Position" Visible="true" DataField="PositionName" UniqueName="PositionName">
                                <ItemTemplate>
                                    <asp:Label ID="lblPositionName" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container, "DataItem.PositionName") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Position Count" Visible="true" DataField="PosCount" UniqueName="PosCount">
                                <ItemTemplate>
                                    <asp:Label ID="lblPosCount" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container, "DataItem.PosCount") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>


                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>


            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="radPagePlayers">
                <asp:CheckBox ID="chkDraftedPlayers" runat="server" Font-Bold="false" CssClass="chkBox" Width="200px" Text="Drafted" AutoPostBack="true" OnCheckedChanged="chkDraftedPlayers_CheckedChanged" />
                <telerik:RadDropDownList ID="rDDPrimPos" AutoPostBack="true" 
                    runat="server">
                </telerik:RadDropDownList>
                <br />

                <asp:Panel ID="pnlMain" runat="server">
                    <telerik:RadRotator ID="RadRotator1"
                        runat="server"
                        Width="100%"
                        Height="400px"
                        CssClass="horizontalRotator"
                        ItemHeight="100px"
                        ItemWidth="100px"
                        Skin="<%$ appSettings:Telerik.Skin%>"
                        ScrollDuration="500" 
                        EnableRandomOrder="true"
                        FrameDuration="500"
                        SlideShowAnimation-Type="Pulse"  
                        RotatorType="Carousel"  
                        
                        DataSourceID="ObjectDataSource1">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" 
                                CropPosition="Top" 
                                ResizeMode="Crop" 
                                ID="RadBinaryImage1" 
                                DataValue='<%#Eval("PlayerImage") %>'
                                AutoAdjustImageControlSize="false" 
                                Height="100px" 
                                Width="90px" 
                                ToolTip='<%#Eval("PlayerName", "Photo of {0}") %>'
                                AlternateText='<%#Eval("PlayerName", "Photo of {0}") %>'></telerik:RadBinaryImage>
                        </ItemTemplate>
                    </telerik:RadRotator>
                </asp:Panel>

                <asp:ObjectDataSource ID="ObjectDataSource1"
                    runat="server" 
                    SelectMethod="ListPlayerPositionSeason" 
                    TypeName="CSBA.BusinessLogicLayer.PlayerBusinessLogic">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="rDDSeason"  Type="Int32" Name="SeasonID" />
                        <asp:ControlParameter ControlID="rDDPrimPos" Type="Int32" Name="PositionID" />
                        <asp:ControlParameter ControlID="chkDraftedPlayers" Type="Boolean" Name="bDrafted" />
                    </SelectParameters>
                </asp:ObjectDataSource>


            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>














</asp:Panel>
<asp:Panel ID="Panel1" runat="server" Height="245px" Width="100%">
    <div style="float: left; width: 100%; padding-left: 0px; padding-right: 0px">
        <uc1:ucPlayerStats runat="server" ID="ucPlayerStats" />
    </div>
</asp:Panel>

<asp:Panel ID="pnlTimer" runat="server">
    <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
    </asp:Timer>
</asp:Panel>


<asp:Label ID="lblMessage" runat="server">

</asp:Label>