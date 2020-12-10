<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyRentals.aspx.cs" Inherits="_3342FinalProject.MyRentals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="global">
        <h3>Properties</h3>
        <div id="propertiesDiv">No properties</div>
        <h3>Payments</h3>
        <asp:Label ID="lblFunds" runat="server" Text="Wallet: $0.00"></asp:Label>
        <div id="paymentsDiv"></div>
    </div>
</asp:Content>
