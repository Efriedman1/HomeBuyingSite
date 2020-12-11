<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="_3342FinalProject.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="card col-8">
            <h3>Payment</h3>
            <div class="container">
                <asp:Label ID="lblFunds" runat="server" Text="Funds: $0.00" CssClass="h4"></asp:Label>
                <label class="h4">Date: </label>
                <asp:Label ID="lblDate" runat="server" Text="" CssClass="h4"></asp:Label>
                <br />
                <asp:Label ID="lblAmount" runat="server" Text="Amount: $0.00" CssClass="h4"></asp:Label>
                <asp:TextBox ID="txtAmount" placeholder="Enter Amount" runat="server" CssClass="form-control col-2 m-2"></asp:TextBox>
                <asp:Button ID="btnPay" runat="server" CssClass="btn btn-primary mb-4" Text="Pay Amount" OnClick="btnPay_Click" />
                <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
