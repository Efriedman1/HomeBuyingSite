<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RetrievePassword.aspx.cs" Inherits="_3342FinalProject.RetrievePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary" OnClick="btnSend_Click" />
</asp:Content>
