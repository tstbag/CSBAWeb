<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTeamRoster.ascx.cs" Inherits="CSBANet.Common.WebControls.ucTeamRoster" %>


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
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <telerik:RadGrid ID="rGridTeam"
            runat="server"
            OnNeedDataSource= "rGridTeam_NeedDataSource"
            OnItemDataBound= "rGridTeam_ItemDataBound"
            OnItemCommand="rGridTeam_ItemCommand"
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
            <MasterTableView DataKeyNames="TeamID"
                CommandItemDisplay="Bottom"
                EditMode="EditForms"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team ID" Visible="false" DataField="SeasonID" UniqueName="SeasonID">
                        <ItemTemplate>
                            <asp:Label ID="lblSeasonID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.SeasonID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Team ID" Visible="false" DataField="TeamID" UniqueName="TeamID">
                        <ItemTemplate>
                            <asp:Label ID="lblTeamID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.TeamID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Player Name" DataField="PlayerName" UniqueName="PlayerName">
                        <ItemTemplate>
                            <asp:Label ID="lblPlayerName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlayerName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>


                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="1st Pos" DataField="Position" UniqueName="Position">
                        <ItemTemplate>
                            <asp:Label ID="lblPrimPosition" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PrimPos") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="2nd Pos" DataField="SecPos" UniqueName="SecPos">
                        <ItemTemplate>
                            <asp:Label ID="lblSecPosition" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SecPos") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="Points" DataField="Points" UniqueName="Points">
                        <ItemTemplate>
                            <asp:Label ID="lblPoints" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Points") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" HeaderText="Player Image" DataField="PlayerImage" UniqueName="PlayerImage">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#Eval("PlayerImage") %>'
                                AutoAdjustImageControlSize="false" Height="80px" Width="62.5px" ToolTip='<%#Eval("PlayerName", "Photo of {0}") %>'
                                AlternateText='<%#Eval("PlayerName", "Photo of {0}") %>'></telerik:RadBinaryImage>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>

            </MasterTableView>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
</asp:Panel>
