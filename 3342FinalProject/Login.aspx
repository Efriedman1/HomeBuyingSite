<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3342FinalProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <div class="card" style="width: 25rem; margin-top: 150px;">
            <div class="card-body">
                <div class="row mb-4">
                    <div class="col-4"></div>
                    <img class="col-4" src="img/icon.png" alt="" width="75" height="75" />
                    <div class="col-4"></div>
                </div>
                <h1 class="h3 mb-3 font-weight-normal">Please Sign-in</h1>
                <label for="inputUsername" class="sr-only">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control mb-2" placeholder="Username" autofocus=""></asp:TextBox>
                <label for="txtPw" class="sr-only">Password</label>
                <asp:TextBox ID="txtPw" runat="server" class="form-control mb-2" placeholder="Password" autofocus=""></asp:TextBox>
                <asp:CheckBox ID="chkCookies" runat="server"/> <label>Save login to my cookies</label>
                <asp:Button ID="btnDeleteCookie" runat="server" CssClass="btn btn-danger mb-2" Text="Delete Cookie" Visible="false" OnClick="btnDeleteCookie_Click"/>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger m-2" Visible="false" Text=""></asp:Label>
                <asp:Button ID="btnSubmitLogin" runat="server" class="btn btn-md btn-primary btn-block" type="submit" Text="Login" OnClick="btnSubmitLogin_Click" />
                <asp:Button ID="btnView" runat="server" class="btn btn-md btn-info btn-block" type="submit" Text="Continue as Guest" OnClick="btnView_Click" />
                <asp:Button ID="btnCreateAccount" runat="server" class="btn btn-link m-2" Text="Create Account" OnClick="btnCreateAccount_Click" />
                <asp:Button ID="btnLostPassword" runat="server" class="btn btn-link" Text="I Forgot My Password" OnClick="btnLostPassword_Click" Visible ="false"/>
                <p class="mt-5 mb-3 text-muted">Copyright &copy; 2020</p>
            </div>
        </div>
    </div>
</asp:Content>
