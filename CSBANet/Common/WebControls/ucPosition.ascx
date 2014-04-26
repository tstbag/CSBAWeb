<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPosition.ascx.cs" Inherits="CSBANet.Common.WebControls.ucPosition" %>



<telerik:RadGrid ID="rGridPosition"
    runat="server"
    OnNeedDataSource="rGridPosition_NeedDataSource"
    OnPreRender="rGridPosition_PreRender"
    OnItemDataBound="rGridPosition_ItemDataBound"
    OnItemCommand="rGridPosition_ItemCommand"
    OnUpdateCommand="rGridPosition_UpdateCommand"
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
    <MasterTableView DataKeyNames="PositionID"
        CommandItemDisplay="None"
        EditMode="EditForms"
        EnableHeaderContextAggregatesMenu="True"
        EnableHeaderContextFilterMenu="True"
        EnableHeaderContextMenu="True">
        <Columns>
            <telerik:GridEditCommandColumn HeaderText="Action" ButtonType="ImageButton">
            </telerik:GridEditCommandColumn>
            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="PositionID" Visible="false" DataField="PositionID" UniqueName="PositionID">
                <ItemTemplate>
                    <asp:Label ID="lblPositionID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.PositionID") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Position TypeID" Visible="false" DataField="PositionTypeID" UniqueName="PositionTypeID">
                <ItemTemplate>
                    <asp:Label ID="lblPositionTypeID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.PositionTypeID") %>'>
                            </asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Position Name" DataField="PositionName" UniqueName="PositionName">
                <ItemTemplate>
                    <asp:Label ID="lblPositionName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionName") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Position Name Long" DataField="PositionNameLong" UniqueName="PositionNameLong">
                <ItemTemplate>
                    <asp:Label ID="lblPositionNameLong" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionNameLong") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>


            <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Max Count" DataField="MaxCount" UniqueName="MaxCount">
                <ItemTemplate>
                    <asp:Label ID="lblMaxCount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaxCount") %>'></asp:Label>
                </ItemTemplate>

            </telerik:GridTemplateColumn>
        </Columns>


        <EditFormSettings EditFormType="Template">
            <EditColumn UniqueName="EditCommandColumn1" ButtonType="PushButton" FilterControlAltText="Filter EditCommandColumn1 column"></EditColumn>
            <FormTemplate>

                <asp:Table ID="tblPositions" runat="server" CellSpacing="2" CellPadding="1" Width="100%" CssClass="float-left"
                    Style="border-collapse: collapse;">
                    <asp:TableRow>
                        <asp:TableCell Width="10%" Visible="false">
                            <asp:Label ID="lblPositionIDLit" runat="server" Text="PositionID">
                                        </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblPositionID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionID") %>'>
                                        </asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow>
                        <asp:TableCell Width="10%" Visible="false">
                            <asp:Label ID="Label2" runat="server" Text="PositionTypeID">
                                        </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblPositionTypeID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionTypeID") %>'>
                                        </asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell Width="10%" Visible="true">
                            <asp:Label ID="lblPositionNameLit" runat="server" Text="Position Name">
                                        </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblPositionName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionName") %>'></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell Width="10%" Visible="true">
                            <asp:Label ID="Label4" runat="server" Text="Position Name Long">
                                        </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <telerik:RadTextBox ID="rTXTPositionNameLong" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionNameLong") %>'></telerik:RadTextBox>
                        </asp:TableCell>
                    </asp:TableRow>


                    <asp:TableRow>
                        <asp:TableCell Width="10%" Visible="true">
                            <asp:Label ID="Label5" runat="server" Text="Max Count">
                                        </asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <telerik:RadNumericTextBox ID="rNTBMaxCount" ShowSpinButtons="true" NumberFormat-DecimalDigits="0" MinValue="1" MaxValue="99" DbValue='<%# DataBinder.Eval(Container, "DataItem.MaxCount") %>' runat="server"></telerik:RadNumericTextBox>
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
