<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDraftStadium.ascx.cs" Inherits="CSBANet.Common.WebControls.ucDraftStadium" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>



<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function OnClientFilesUploaded(sender, args) {
            $find('<%=RadAjaxManager1.ClientID %>').ajaxRequest();
        }
    </script>
</telerik:RadScriptBlock>

<%--<h2>Draft Stadium
    </h2>--%>

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
            <asp:Label ID="lblSeason" runat="server" Text="Season"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDropDownList ID="rDDSeason" runat="server" Skin="<%$ appSettings:Telerik.Skin%>" OnSelectedIndexChanged="rDDSeason_SelectedIndexChanged" AutoPostBack="true">
            </telerik:RadDropDownList>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

<asp:Panel ID="pnlPickStadium" runat="server" Width="50%">

    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <telerik:RadGrid ID="rGridStadium"
            runat="server"
            PageSize="4"
            AllowPaging="true"
            PagerStyle-Mode="Slider"
            PagerStyle-Position="Bottom"
            OnNeedDataSource="rGridStadium_NeedDataSource"
            OnItemDataBound="rGridStadium_ItemDataBound"
            OnItemCommand="rGridStadium_ItemCommand"
            AutoGenerateColumns="False"
            BorderWidth="1px"
            AllowFilteringByColumn="True"
            AllowSorting="True"
            Skin="<%$ appSettings:Telerik.Skin%>"
            CellSpacing="0"
            GridLines="None"
            AllowMultiRowEdit="True"
            AllowMultiRowSelection="True">
            <PagerStyle />
            <GroupingSettings CaseSensitive="False" />
            <MasterTableView DataKeyNames="StadiumID"
                CommandItemDisplay="Bottom"
                EditMode="InPlace"
                EnableHeaderContextAggregatesMenu="True"
                EnableHeaderContextFilterMenu="True"
                EnableHeaderContextMenu="True">
                <Columns>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <telerik:RadButton ID="rBTNSelect" runat="server" AutoPostBack="true" Text="Draft"></telerik:RadButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
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
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" AllowFiltering="false" HeaderText="Stadium Image" DataField="StadiumImage" UniqueName="PlayerImage">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#Eval("StadiumImage") %>'
                                AutoAdjustImageControlSize="false" Height="80px" Width="80px" ToolTip='<%#Eval("StadiumName", "Photo of {0}") %>'
                                AlternateText='<%#Eval("StadiumName", "Photo of {0}") %>'></telerik:RadBinaryImage>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn Text="Delete" CommandName="Delete" UniqueName="Delete" ConfirmText="Are you sure you want to delete this?" ButtonType="ImageButton" />
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>

</asp:Panel>
