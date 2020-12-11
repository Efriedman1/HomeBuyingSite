<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PropertyControl.ascx.cs" Inherits="_3342FinalProject.PropertyControl" %>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
<div class="row">
    <div class="col-2"></div>
    <div class="col-2">
        <asp:Image ID="imgProperty" runat="server" Height="140px" Width="120px" />
    </div>
    <div class="col-6">
        <asp:Label ID="lblAddress" runat="server" CssClass="h5"></asp:Label>
        <br />
        <asp:Label ID="lblRent" runat="server"></asp:Label><br />
        <asp:Label ID="lblBedAmount" runat="server"></asp:Label><br />
        <asp:Label ID="lblBathAmount" runat="server"></asp:Label><br />
        <asp:Label ID="lblDescription" runat="server"></asp:Label>
    </div>
    <div class="col-2">
    </div>
</div>
