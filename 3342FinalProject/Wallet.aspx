<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Wallet.aspx.cs" Inherits="_3342FinalProject.Wallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblName" runat="server" Text="User Name"></asp:Label>
        <asp:Label ID="lblFunds" runat="server" Text="Funds: $0.00"></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control col-2"></asp:TextBox>
        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add Funds" OnClick="btnAdd_Click" />
        <asp:Label ID="lblError" runat="server" Visible ="false"></asp:Label>
    </div>
</asp:Content>

