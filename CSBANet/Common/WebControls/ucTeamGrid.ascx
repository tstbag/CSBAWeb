<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTeamGrid.ascx.cs" Inherits="CSBANet.Common.WebControls.ucTeamGrid" %>

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

<asp:Panel ID="pnlTeam" runat="server" Width="70%">
    <h2>
        Manage Team
    </h2>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <telerik:RadGrid ID="rGridTeam"
            runat="server"
            OnNeedDataSource="rGridTeam_NeedDataSource"
            OnItemDataBound="rGridTeam_ItemDataBound"
            OnItemCommand="rGridTeam_ItemCommand"
            OnUpdateCommand="rGridTeam_UpdateCommand"
            OnInsertCommand="rGridTeam_InsertCommand"
            OnDeleteCommand="rGridTeam_DeleteCommand"
            AutoGenerateColumns="False"
            BorderWidth="1px"
            AllowFilteringByColumn="True"
            AllowSorting="True"
            Skin="Web20"
            CellSpacing="0"
            GridLines="None"
            AllowMultiRowEdit="True"
            AllowMultiRowSelection="True">
            <GroupingSettings CaseSensitive="False" />
            <MasterTableView DataKeyNames="TeamID"
                CommandItemDisplay="Bottom"
                EditMode="EditForms"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>

                    <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
                    </telerik:GridEditCommandColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team ID" Visible="false" DataField="TeamID" UniqueName="TeamID">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.TeamID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team Name" DataField="TeamName" UniqueName="TeamName">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Owner Name" DataField="OwnerName" UniqueName="OwnerName">
                        <ItemTemplate>
                            <asp:Label ID="lblOwnerName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" Visible="false" HeaderText="Owner UserID" DataField="OwnerUserID" UniqueName="OwnerUserID">
                        <ItemTemplate>
                            <asp:Label ID="lblOwnerUserID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerUserID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Owner User Name" DataField="UserName" UniqueName="UserName">
                        <ItemTemplate>
                            <asp:Label ID="lblOwnerUserName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Owner Email" DataField="OwnerEmail" UniqueName="OwnerEmail">
                        <ItemTemplate>
                            <asp:Label ID="lblOwnerEmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerEmail") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" HeaderText="Team Image" DataField="TeamImage" UniqueName="TeamImage">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#Eval("TeamImage") %>'
                                AutoAdjustImageControlSize="false" Height="80px" Width="80px" ToolTip='<%#Eval("TeamName", "Photo of {0}") %>'
                                AlternateText='<%#Eval("TeamName", "Photo of {0}") %>'></telerik:RadBinaryImage>
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
                                    <asp:Label ID="lblTeamIDlit" runat="server" Text="TeamID">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblTeamID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TeamID") %>'>
                                    </asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblTeamName" runat="server" Text="Team Name">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <telerik:RadTextBox ID="rTBTeamName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TeamName") %>'>
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="reqTeamName" runat="server" Font-Bold="true" ForeColor="Red" ControlToValidate="rTBTeamName" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblOwnerName" runat="server" Text="Owner Name">
                                    </asp:Label>
                                </asp:TableCell>

                                <asp:TableCell>
                                    <telerik:RadTextBox ID="rTBOwnerName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerName") %>'>
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="reqOwnerName" runat="server" Font-Bold="true" ForeColor="Red" ControlToValidate="rTBOwnerName" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblOwnerUserIDlit" runat="server" Text="Owner UserID">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblOwnerUserID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerUserID") %>'>
                                    </asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblUserNameLit" runat="server" Text="Owner User Name">
                                    </asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <telerik:RadDropDownList ID="rDDUserName" runat="server">
                                    </telerik:RadDropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Width="10%">
                                    <asp:Label ID="lblOwnerEmail" runat="server" Text="Owner Email">
                                    </asp:Label>
                                </asp:TableCell>

                                <asp:TableCell>
                                    <telerik:RadTextBox ID="rTBOwnerEmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OwnerEmail") %>'>
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Bold="true" ForeColor="Red" ControlToValidate="rTBOwnerEmail" ErrorMessage="* Required"></asp:RequiredFieldValidator>
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
