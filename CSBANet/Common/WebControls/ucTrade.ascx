<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTrade.ascx.cs" Inherits="CSBANet.Common.WebControls.ucTrade" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function OnClientFilesUploaded(sender, args) {
            $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
        }
    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadImageEditor1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

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

    </asp:TableRow>
</asp:Table>


<asp:Panel ID="pnlTrade" runat="server" Width="60%">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <telerik:RadGrid ID="rGridTrade"
            runat="server"
            PageSize="4"
            AllowPaging="true"
            PagerStyle-Mode="Slider"
            PagerStyle-Position="Bottom"
            OnNeedDataSource="rGridPlayer_NeedDataSource"
            OnPreRender="rGridPlayer_PreRender"
            OnItemDataBound="rGridPlayer_ItemDataBound"
            OnItemCommand="rGridPlayer_ItemCommand"
            OnUpdateCommand="rGridPlayer_UpdateCommand"
            OnInsertCommand="rGridPlayer_InsertCommand"
            OnDeleteCommand="rGridPlayer_DeleteCommand"
            AutoGenerateColumns="False"
            BorderWidth="1px"
            AllowFilteringByColumn="True"
            AllowSorting="True"
            Skin="<%$ appSettings:Telerik.Skin%>"
            CellSpacing="0"
            GridLines="None"
            AllowMultiRowEdit="True"
            AllowMultiRowSelection="True">
            <GroupingSettings CaseSensitive="False" />
            <MasterTableView DataKeyNames="SeasonID, TradeGUID"
                CommandItemDisplay="Bottom"
                EditMode="EditForms"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>
                    <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
                    </telerik:GridEditCommandColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Season ID" Visible="false" DataField="SeasonID" UniqueName="SeasonID">
                        <ItemTemplate>
                            <asp:Label ID="lblSeasonID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Trade GUID" Visible="false" DataField="TradeGUID" UniqueName="TradeGUID">
                        <ItemTemplate>
                            <asp:Label ID="lblTradeGUID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.TradeGUID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Proposed Date" Visible="true" DataField="ProposedDate" UniqueName="ProposedDate">
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="rCALProposedDate" Enabled="false" runat="server" Width="125px" SelectedDate='<%# DataBinder.Eval(Container, "DataItem.ActionDate") %>'></telerik:RadDatePicker>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team ID" Visible="false" DataField="TeamID" UniqueName="TeamID">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamID" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container, "DataItem.TeamID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team Name" Visible="true" DataField="TeamName" UniqueName="TeamName">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamName" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Action Date" Visible="true" DataField="ActionDate" UniqueName="ActionDate">
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="rCALActionDate" Enabled="false" runat="server" Width="125px" SelectedDate='<%# DataBinder.Eval(Container, "DataItem.ActionDate") %>'></telerik:RadDatePicker>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Trade Status" Visible="true" DataField="TradeStatus" UniqueName="TradeStatus">
                        <ItemTemplate>
                            <asp:Label ID="lblTradeStatus" runat="server" Visible="true" Text='<%# DataBinder.Eval(Container, "DataItem.TradeStatus") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />

                </Columns>

                <EditFormSettings EditFormType="Template">
                    <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                    <FormTemplate>
                    </FormTemplate>
                </EditFormSettings>

            </MasterTableView>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</asp:Panel>
