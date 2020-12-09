<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Property.aspx.cs" Inherits="_3342FinalProject.Property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Property</h1>
    <asp:Image ID="imgProperty" runat="server" Height="140px" Width="120px" />
    <asp:Label ID="lblProperty" runat="server"></asp:Label>
    <asp:Label ID="lblAddress" runat="server"></asp:Label>
    <asp:Label ID="lblRent" runat="server"></asp:Label>
    <asp:Label ID="lblBedAmount" runat="server"></asp:Label>
    <asp:Label ID="lblBathAmount" runat="server"></asp:Label>
    <asp:Label ID="lblDescription" runat="server"></asp:Label>
    <asp:Button ID="btnRent" runat="server" Text="Rent Property" OnClick="btnRent_Click" CssClass="btn btn-primary"/>
</asp:Content>
