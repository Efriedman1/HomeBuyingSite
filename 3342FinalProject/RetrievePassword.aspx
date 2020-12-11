<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RetrievePassword.aspx.cs" Inherits="_3342FinalProject.RetrievePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col-8">
            <h3 class="mt-4">Retrieve Password</h3>
            <asp:Label ID="lblEmail" runat="server" Text="Please enter your email and answer a security question to retrieve your password."></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control col-3 m-2"></asp:TextBox>
            <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary m-2" OnClick="btnSend_Click" Text="Verify" />
            <asp:Label ID="lblSecurity" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtSecurity" runat="server" Visible="false" CssClass="form-control col-3 m-2"></asp:TextBox>
            <asp:Button ID="btnSecurity" runat="server" CssClass="btn btn-primary m-2" OnClick="btnSecurity_Click" Text="Verify" Visible="false" />
            <asp:Label ID="lblStatus" runat="server" Visible="false"></asp:Label>
            <asp:HiddenField ID="hdAnswer" Value="" runat="server" />
            <asp:HiddenField ID="hdID" Value="" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
