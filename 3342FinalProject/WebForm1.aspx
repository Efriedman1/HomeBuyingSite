<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_3342FinalProject.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                Funds :
        <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <asp:TextBox ID="lblFunds" runat="server"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Refresh" OnClick="btnAdd_Click" />
            </div>
        </div>
    </form>
</body>
</html>
