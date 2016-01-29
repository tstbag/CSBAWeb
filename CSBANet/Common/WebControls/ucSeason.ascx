<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeason.ascx.cs" Inherits="CSBANet.Controls.ucSeason" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<script type="text/javascript">
    function OnClientFilesUploaded(sender, args) {
        $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
    }
    function DoPostBackWithRowIndex(rowIndex) {
        if (document.getElementById('<%=HdnSelectedRowIndex.ClientID%>') != null) {
            document.getElementById('<%=HdnSelectedRowIndex.ClientID%>').value = rowIndex;
        }
        return true;
    }
</script>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rGridSeason">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rGridSeason"></telerik:AjaxUpdatedControl>
                <telerik:AjaxUpdatedControl ControlID="txtTest" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>


<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
</telerik:RadAjaxLoadingPanel>
<asp:Panel runat="server" Width="50%">
    <asp:HiddenField ID="HdnSelectedRowIndex" runat="server" />
    <telerik:RadGrid ID="rGridSeason"
        runat="server" PagerStyle-Mode="Slider" PageSize="7"
        OnNeedDataSource="rGridSeason_NeedDataSource"
        OnPreRender="rGridSeason_PreRender"
        OnItemDataBound="rGridSeason_ItemDataBound"
        OnItemCommand="rGridSeason_ItemCommand"
        OnUpdateCommand="rGridSeason_UpdateCommand"
        OnInsertCommand="rGridSeason_InsertCommand"
        OnDeleteCommand="rGridSeason_DeleteCommand"
        AutoGenerateColumns="False"
        BorderWidth="1px"
        AllowFilteringByColumn="True"
        AllowSorting="True"
        Skin="<%$ appSettings:Telerik.Skin%>"
        AllowMultiRowEdit="True"
        AllowMultiRowSelection="True">
        <GroupingSettings CaseSensitive="False" />
        <MasterTableView DataKeyNames="SeasonID"
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
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Season Name" DataField="SeasonName" UniqueName="SeasonName">
                    <ItemTemplate>
                        <asp:Label ID="lblSeasonName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderStyle-Width="125px" HeaderText="Draft Date" DataField="DraftDate" UniqueName="DraftDate">
                    <ItemTemplate>
                        <telerik:RadDatePicker ID="rDTSeasonStart" Enabled="false" runat="server" Width="125px" SelectedDate='<%# DataBinder.Eval(Container, "DataItem.DraftDate") %>'></telerik:RadDatePicker>
                    </ItemTemplate>
                    <HeaderStyle Width="125px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderStyle-Width="125px" HeaderText="Start Points" DataField="StartPoints" UniqueName="StartPoints">
                    <ItemTemplate>
                        <asp:Label ID="lblStartPoints" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartPoints") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="125px" />
                </telerik:GridTemplateColumn>


                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderStyle-Width="125px" HeaderText="Min Bid" DataField="MinBid" UniqueName="MinBid">
                    <ItemTemplate>
                        <asp:Label ID="lblMinBid" runat="server" Width="125px" Text='<%# DataBinder.Eval(Container, "DataItem.MinBid") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="125px" />
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderStyle-Width="125px" HeaderText="Active" DataField="Active" UniqueName="Active">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkActive" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container, "DataItem.Active") %>' />
                    </ItemTemplate>
                    <HeaderStyle Width="125px" />
                </telerik:GridTemplateColumn>


                <telerik:GridButtonColumn Text="Select" CommandName="Select" UniqueName="Clear" ConfirmText="Are you sure you want to select this season?" ButtonType="PushButton" ConfirmDialogType="RadWindow">
                </telerik:GridButtonColumn>
                <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />
                <telerik:GridButtonColumn Text="Clear" CommandName="Clear" UniqueName="Clear" ConfirmText="Are you sure you want to reset this season?" ButtonType="PushButton" ConfirmDialogType="RadWindow">
                    <ItemStyle Height="25px" Width="25px" />
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings EditFormType="Template">
                <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                <FormTemplate>
                    <asp:Table ID="tblEnterAddress" runat="server" CellSpacing="2" CellPadding="1" Width="100%"
                        Style="border-collapse: collapse;">
                        <asp:TableRow Visible="false">
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblSeason" runat="server" Text="SeasonID">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblSeasonID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonID") %>'>
                                </asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="10%">
                                <asp:Label ID="lblSeasonName" runat="server" Text="Season Name">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBSeason" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonName") %>'>
                                </telerik:RadTextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="DraftDate" runat="server" Text="Draft Date">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadCalendar ID="calSeasonStart" runat="server"></telerik:RadCalendar>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblStartPoints" runat="server" Text="Start Points">
                                </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadTextBox ID="rTBStartPoints" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StartPoints") %>'>
                                </telerik:RadTextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblMinBid" runat="server" Text="Min Bid"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadNumericTextBox ID="rNTBMinBid" ShowSpinButtons="true" AutoPostBack="true" NumberFormat-DecimalDigits="0" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MinBid") %>'>
                                </telerik:RadNumericTextBox>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CheckBox ID="chkEditActive" runat="server" Enabled="true" Checked='<%# DataBinder.Eval(Container, "DataItem.Active") %>' />
                            </asp:TableCell>
                        </asp:TableRow>
                       



                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2">
                                <telerik:RadButton ID="btnUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                                    runat="server" ButtonType="SkinnedButton" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                </telerik:RadButton>
                                &nbsp;
                               
                                <telerik:RadButton ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False"
                                    CommandName="Cancel">
                                </telerik:RadButton>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </FormTemplate>
            </EditFormSettings>
        </MasterTableView>
        <PagerStyle Mode="Slider" />
    </telerik:RadGrid>

</asp:Panel>
