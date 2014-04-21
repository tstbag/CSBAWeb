<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPlayerStats.ascx.cs" Inherits="CSBANet.Common.WebControls.ucPlayerStats" %>


<telerik:RadGrid ID="rGridStats"
    runat="server" CssClass="Lables"
    OnNeedDataSource="rGridStats_NeedDataSource"
    AutoGenerateColumns="true" 
    AllowFilteringByColumn="False"
    AllowSorting="True"
    Skin="<%$ appSettings:Telerik.Skin%>"
    CellSpacing="0"
    GridLines="None"
    AllowMultiRowEdit="True"
    AllowMultiRowSelection="True">
    <PagerStyle />
</telerik:RadGrid>