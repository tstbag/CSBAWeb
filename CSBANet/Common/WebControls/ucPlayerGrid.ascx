<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPlayerGrid.ascx.cs" Inherits="CSBANet.Common.WebControls.ucPlayerGrid" %>
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

<asp:Panel ID="pnlPlayer" runat="server" Width="60%">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <telerik:RadGrid ID="rGridPlayer"
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
            <MasterTableView DataKeyNames="PlayerGUID"
                CommandItemDisplay="Bottom"
                EditMode="EditForms"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>
                    <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
                    </telerik:GridEditCommandColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Player GUID" Visible="false" DataField="PlayerGUID" UniqueName="PlayerGUID">
                        <ItemTemplate>
                            <asp:Label ID="lblPlayerGUID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.PlayerGUID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Player Name" DataField="PlayerName" UniqueName="PlayerName">
                        <ItemTemplate>
                            <asp:Label ID="lblPlayerName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlayerName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Player Primary Position" DataField="PrimPosNameLong" UniqueName="PrimPosNameLong">
                        <ItemTemplate>
                            <asp:Label ID="lblPrimPosName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PrimPosNameLong") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Player Secondary Position" DataField="SecPosNameLong" UniqueName="SecPosNameLong">
                        <ItemTemplate>
                            <asp:Label ID="lblSecPosName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SecPosNameLong") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" HeaderText="Player Image" DataField="PlayerImage" UniqueName="PlayerImage">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#Eval("PlayerImage") %>'
                                AutoAdjustImageControlSize="false" Height="80px" Width="62.5px" ToolTip='<%#Eval("PlayerName", "Photo of {0}") %>'
                                AlternateText='<%#Eval("PlayerName", "Photo of {0}") %>'></telerik:RadBinaryImage>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
                    <FormTemplate>

                        <div style="float: left; padding-top: 10px; padding-left: 40px">
                            <asp:Label ID="lblPicture" runat="server" CssClass="LargerLabels" Text='<%# DataBinder.Eval(Container, "DataItem.PlayerName") %>'></asp:Label>
                            <br />
                            <telerik:RadBinaryImage runat="server" ID="imgPlayer" DataValue='<%#Eval("PlayerImage") %>' CssClass="float-right"
                                AutoAdjustImageControlSize="false" Width="250px" Height="320px" />
                        </div>

                        <div style="float: right; width: 50%">

                            <asp:Table ID="tblEnterAddress" runat="server" CellSpacing="2" CellPadding="1" Width="100%" CssClass="float-left"
                                Style="border-collapse: collapse;">
                                <asp:TableRow>
                                    <asp:TableCell Width="10%" Visible="false">
                                        <asp:Label ID="lblPlayerGUIDLit" runat="server" Text="PlayerGUID">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="lblPlayerGUID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlayerGUID") %>'>
                                        </asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell Width="10%">
                                        <asp:Label ID="lblPlayerName" runat="server" Text="Player Name" Width="100%">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <telerik:RadTextBox ID="rTBPlayerName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlayerName") %>'>
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="reqPlayerName" runat="server" Font-Bold="true" ForeColor="Red" ControlToValidate="rTBPlayerName" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell Width="10%">
                                        <asp:Label ID="lblPrimaryPosition" runat="server" Text="Primary Position">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <telerik:RadDropDownList ID="rDDPrimPos" runat="server"></telerik:RadDropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell Width="10%">
                                        <asp:Label ID="lblSecondaryPosition" runat="server" Text="Secondary Position">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <telerik:RadDropDownList ID="rDDSecPos" runat="server"></telerik:RadDropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell>

                                    </asp:TableCell>
                                    <asp:TableCell Width="100%">
                                        <telerik:RadAsyncUpload ID="AsyncUpload1" runat="server"
                                            OnClientFilesUploaded="OnClientFilesUploaded" OnFileUploaded="AsyncUpload1_FileUploaded"
                                            MaxFileSize="102097152" AllowedFileExtensions="jpg,png,gif,bmp"
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
                        </div>

                    </FormTemplate>
                </EditFormSettings>

            </MasterTableView>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</asp:Panel>
