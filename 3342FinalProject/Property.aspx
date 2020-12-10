<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Property.aspx.cs" Inherits="_3342FinalProject.Property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Property</h1>
    <asp:Image ID="imgProperty" runat="server" Height="140px" Width="120px" />
    <asp:Label ID="lblProperty" runat="server"></asp:Label>
    <asp:Label ID="lblAddress" runat="server"></asp:Label>
    <asp:Label ID="lblRent" runat="server"></asp:Label>
    <asp:Label ID="lblBedAmount" runat="server"></asp:Label>
    <asp:Label ID="lblBathAmount" runat="server"></asp:Label>
    <asp:Label ID="lblDescription" runat="server"></asp:Label>
    <asp:Button ID="btnRent" runat="server" Text="Rent Property" OnClick="btnRent_Click" CssClass="btn btn-primary"/>
     <br />
     <asp:Button ID="btnCreate" runat="server" Text="Edit Property Details" OnClick="btnCreate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete Property" OnClick="btnDelete_Click" />
         <p><asp:Label ID="lblImage" runat="server" Text="Property Image: " class="mr-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
                <asp:Image ID="PropImage" runat="server" ImageUrl="~/images/default.png" Width="50" Height="50" class="rounded" Visible="False" />
                <asp:DropDownList ID="ddImage" runat="server" AutoPostBack="True" Visible="False">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>                  
                    <asp:ListItem Selected="True" Value="default">Default</asp:ListItem>
                </asp:DropDownList>
        <p><asp:Label ID="lblName" runat="server" Text="Landlord Name: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbName" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
          <p><asp:Label ID="Label1" runat="server" Text="Address: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbAddress" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="lblBeds" runat="server" Text="# of Bedrooms: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbBeds" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="lblBaths" runat="server" Text="# of Bathrooms: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbBaths" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="Label2" runat="server" Text="Monthly Rent ($): " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbRent" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="Label3" runat="server" Text="Property Description: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
    <p><asp:TextBox ID="tbDescription" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
   
        <br />
    <asp:Button ID="btnBack" runat="server" class="btn btn-md btn-info my-2 my-sm-0" type="submit" Text="Back" Width="100px" OnClick="btnBack_Click" Visible="False" />
        <asp:Button ID="btnSave" runat="server" class="btn btn-md btn-primary my-2 my-sm-0" type="submit" Text="Save" Width="100px" OnClick="btnSubmit_Click" Visible="False"/>

</asp:Content>
