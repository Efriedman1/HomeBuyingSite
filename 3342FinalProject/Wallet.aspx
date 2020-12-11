<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Wallet.aspx.cs" Inherits="_3342FinalProject.Wallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-3">
        <div class="col-2"></div>
        <div class="card col-8">
            <h3>My Wallet</h3>
            <div class="container">
                <div>
                    <label class="h4">Name: </label>
                    <asp:Label ID="lblName" runat="server" Text="User Name" CssClass="h4"></asp:Label>
                    <div>
                        <br />
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <asp:Label ID="lblFunds" runat="server"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <asp:TextBox ID="txtAmount" placeholder="Enter Amount" runat="server" CssClass="form-control col-2 m-2"></asp:TextBox>
                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary mb-4" Text="Add Funds" OnClick="btnAdd_Click" />
                    </div>
                </div>
                <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>

