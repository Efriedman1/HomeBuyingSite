<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3342FinalProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <div class="card" style="width: 25rem; margin-top: 150px;">
            <div class="card-body">
                <img class="mb-4" src="" alt="" width="75" height="75" />
                <h1 class="h3 mb-3 font-weight-normal">Please Sign-in</h1>
                <label for="inputUsername" class="sr-only">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username" autofocus=""></asp:TextBox>
                <label for="txtPw" class="sr-only">Password</label>
                <asp:TextBox ID="txtPw" runat="server" class="form-control" placeholder="Password" autofocus=""></asp:TextBox>
                <p>
                    <asp:RadioButtonList ID="selectAccountType" runat="server" CssClass="text-left">
                        <asp:ListItem>Renter</asp:ListItem>
                        <asp:ListItem>Landlord</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <asp:Button ID="btnSubmitLogin" runat="server" class="btn btn-md btn-primary btn-block" type="submit" Text="Login" OnClick="btnSubmitLogin_Click" />
                <asp:Button ID="btnView" runat="server" class="btn btn-md btn-info btn-block" type="submit" Text="Continue as Guest" OnClick="btnView_Click" />
                <asp:Button ID="btnCreateAccount" runat="server" class="btn btn-link" Text="Create Account" OnClick="btnCreateAccount_Click" />
                <p class="mt-5 mb-3 text-muted">Copyright &copy; 2020</p>
            </div>
        </div>
    </div>
</asp:Content>
