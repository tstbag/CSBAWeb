<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPlayerStats.ascx.cs" Inherits="CSBANet.Common.WebControls.ucPlayerStats" %>


<telerik:RadGrid ID="rGridStats"
    runat="server" CssClass="Lables"
    AutoGenerateColumns="true" Width="100%"
    AllowFilteringByColumn="False"
    AllowSorting="False"
    Skin="<%$ appSettings:Telerik.Skin%>"
    CellSpacing="0"
    GridLines="Both">
    <PagerStyle />
    <GroupingSettings CaseSensitive="False" RetainGroupFootersVisibility="true" />

    <MasterTableView AutoGenerateColumns="true"
        CommandItemDisplay="None"
        DataKeyNames="SeasonName, PlayerName, PositionName"
        GroupLoadMode="Client"
        HorizontalAlign="NotSet" 
         AllowSorting="true"
        ShowGroupFooter="false">
   
        <GroupHeaderTemplate>
            <asp:Table ID="tblGroupHeaderTemplate" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="left">
                        <asp:Label ID="lblGroupHeader" runat="server" Font-Size="Medium" Font-Bold="true" Text='<%# DataBinder.Eval(Container, "DataItem.PositionName")%>'>
                        </asp:Label>
                        <asp:Label ID="lblGroupRole" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PositionName")%>' Visible="false"> 
                        </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </GroupHeaderTemplate>

        <SortExpressions>
            <telerik:GridSortExpression FieldName="PositionName, PlayerName " SortOrder="Ascending" />
        </SortExpressions>

        <GroupByExpressions>
            <telerik:GridGroupByExpression>
                <SelectFields>
                    <telerik:GridGroupByField FieldAlias="PositionName" FieldName="PositionName" HeaderText="Position Name" />
                </SelectFields>
                <GroupByFields>
                    <telerik:GridGroupByField FieldName="PositionName" HeaderText="Position Name" />
                </GroupByFields>
            </telerik:GridGroupByExpression>
        </GroupByExpressions>
    </MasterTableView>

</telerik:RadGrid>