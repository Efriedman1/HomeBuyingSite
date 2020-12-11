<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RetrievePassword.aspx.cs" Inherits="_3342FinalProject.RetrievePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Retrieve Password</h3>
    <label>Please enter your email and answer a security question to retrieve your password.</label>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary" OnClick="btnSend_Click" Text="Verify"/>
    <asp:Label ID="lblSecurity" runat="server" Visible="false"></asp:Label>
    <asp:TextBox ID="txtSecurity" runat="server" Visible="false" ></asp:TextBox>
    <asp:Button ID="btnSecurity" runat="server" CssClass="btn btn-primary" OnClick="btnSecurity_Click" Text="Verify" Visible="false"/>
    <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
</asp:Content>
