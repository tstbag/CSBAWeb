<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucStadium.ascx.cs" Inherits="CSBANet.Common.WebControls.ucStadium" %>

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

<asp:Panel ID="pnlStadium" runat="server" Width="50%">
    <h2>
        Manage Stadium
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <telerik:RadGrid ID="rGridStadium"
            runat="server" 
            PageSize="4" 
            AllowPaging="true" PagerStyle-Mode="Slider" PagerStyle-Position="Bottom"            
            OnNeedDataSource="rGridStadium_NeedDataSource"
            OnItemDataBound="rGridStadium_ItemDataBound"
            OnItemCommand="rGridStadium_ItemCommand"
            OnUpdateCommand="rGridStadium_UpdateCommand"
            OnInsertCommand="rGridStadium_InsertCommand"
            OnDeleteCommand="rGridStadium_DeleteCommand" OnPreRender="rGridStadium_PreRender"
            AutoGenerateColumns="False"
            BorderWidth="1px"
            AllowFilteringByColumn="True"
            AllowSorting="True"
            Skin="Web20"
            CellSpacing="0"
            GridLines="None"
            AllowMultiRowEdit="True"
            AllowMultiRowSelection="True">
            <PagerStyle  />

            <GroupingSettings CaseSensitive="False" />
            <MasterTableView DataKeyNames="StadiumID"
                CommandItemDisplay="Bottom"
                EditMode="EditForms"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>

                    <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
                    </telerik:GridEditCommandColumn>



                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Stadium ID" Visible="false" DataField="StadiumID" UniqueName="StadiumID">
                        <ItemTemplate>
                            <asp:Label ID="lblStadiumID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.StadiumID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Stadium Name" DataField="StadiumName" UniqueName="StadiumName">
                        <ItemTemplate>
                            <asp:Label ID="lblStadiumName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StadiumName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Active" DataField="Active_FLG" UniqueName="Active_Flg">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Active_Flg") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" HeaderText="Stadium Image" DataField="StadiumImage" UniqueName="PlayerImage">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#Eval("StadiumImage") %>'
                                AutoAdjustImageControlSize="false" Height="80px" Width="80px" ToolTip='<%#Eval("StadiumName", "Photo of {0}") %>'
                                AlternateText='<%#Eval("StadiumName", "Photo of {0}") %>'></telerik:RadBinaryImage>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                    <FormTemplate>
                        <asp:Table ID="tblEnterAddress" runat="server" CellSpacing="2" CellPadding="1" BorderWidth="1px" Width="100%"
                            Style="border-collapse: collapse;">
                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblStadiumIDLit" runat="server" Text="StadiumID">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblStadiumID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StadiumID") %>'>
                                    </asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblStadiumName" runat="server" Text="Stadium Name">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <telerik:RadTextBox ID="rTBStadiumName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.StadiumName") %>'>
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="reqStadiumName" runat="server" Font-Bold="true" ForeColor="Red" ControlToValidate="rTBStadiumName" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblActive" runat="server" Text="Active">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:CheckBox ID="chkActive" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell>

                                </asp:TableCell>
                                <asp:TableCell Width="100%">
                                    <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server"
                                        OnClientFilesUploaded="OnClientFilesUploaded" OnFileUploaded="AsyncUpload1_FileUploaded"
                                        MaxFileSize="2097152" AllowedFileExtensions="jpg,png,gif,bmp"
                                        AutoAddFileInputs="false" Localization-Select="Upload" />
                                    <asp:Label ID="Label1" Text="*Size limit: 2MB" runat="server" Style="font-size: 10px;"></asp:Label>

                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2">
                                    <telerik:RadButton ID="btnUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                                        runat="server" ButtonType="SkinnedButton" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                    </telerik:RadButton>
                                    &nbsp;
                                <telerik:RadButton ID="btnCancel" ButtonType="SkinnedButton" Text="Cancel" runat="server" CausesValidation="False"
                                    CommandName="Cancel">
                                </telerik:RadButton>

                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </FormTemplate>
                </EditFormSettings>

            </MasterTableView>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</asp:Panel>
