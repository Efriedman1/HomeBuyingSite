<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="_3342FinalProject.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <div class="card" style="width: 25rem; margin-top: 150px;">
            <div class="card-body">
                <img class="mb-4" src="" alt="" width="75" height="75" />
                <h1 class="h3 mb-3 font-weight-normal">Create An Account</h1>
                <label for="txtUsername" class="">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username" autofocus=""></asp:TextBox>
                <label for="txtEmail" class="">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <label for="txtPw1" class="">Password</label>
                <asp:TextBox ID="txtPw1" runat="server" class="form-control" placeholder="Password" autofocus=""></asp:TextBox>
                <label for="txtPw2" class="">Verify Password</label>
                <asp:TextBox ID="txtPw2" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <label for="txtAddress" class="">What is the name of your first pet?</label>
                <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <label for="txtBilling" class="">What is the name of your first pet?</label>
                <asp:TextBox ID="txtBilling" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <label for="txtSecurity1" class="">What is the name of your first pet?</label>
                <asp:TextBox ID="txtSecurity1" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <label for="txtSecurity2" class="">What is your mother's maiden name?</label>
                <asp:TextBox ID="txtSecurity2" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <label for="txtSecurity3" class="">What is the name of your kindergarten teacher?</label>
                <asp:TextBox ID="txtSecurity3" runat="server" class="form-control" placeholder="Verify Password" autofocus=""></asp:TextBox>
                <p>
                    <label for="rbType" class="">What type of user are you?</label>
                    <asp:RadioButtonList ID="rbType" runat="server" CssClass="text-left">
                        <asp:ListItem>Renter</asp:ListItem>
                        <asp:ListItem>Landlord</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <asp:Button ID="btnCreateAccount" runat="server" class="btn btn-md btn-primary btn-block" type="submit" Text="Create Account" OnClick="btnCreateAccount_Click" />
                <asp:Button ID="btnReturn" runat="server" class="btn btn-link" Text="Return to Login Screen" OnClick="btnReturn_Click" />
                <p class="mt-5 mb-3 text-muted">Copyright &copy; 2020</p>
            </div>
        </div>
    </div>
</asp:Content>
