﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MyProperties.aspx.cs" Inherits="_3342FinalProject.MyProperties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnCreate" runat="server" Text="Add a Property" OnClick="btnCreate_Click" />
        <p><asp:Label ID="lblName" runat="server" Text="Landlord Name: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbName" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
          <p><asp:Label ID="lblAddress" runat="server" Text="Address: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbAddress" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="lblBeds" runat="server" Text="# of Bedrooms: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbBeds" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="lblBaths" runat="server" Text="# of Bathrooms: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbBaths" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="lblRent" runat="server" Text="Monthly Rent ($): " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
        <p><asp:TextBox ID="tbRent" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
      <p><asp:Label ID="lblDescription" runat="server" Text="Property Description: " class="my-sm-2" Font-Bold="True" Visible="False"></asp:Label></p>
    <p><asp:TextBox ID="tbDescription" runat="server" class="form-control my-2 my-sm-0" Width="500px" Visible="False" ></asp:TextBox></p>
        <br />
    <asp:Button ID="btnBack" runat="server" class="btn btn-md btn-info my-2 my-sm-0" type="submit" Text="Back" Width="100px" OnClick="btnBack_Click" Visible="False" />
        <asp:Button ID="btnSave" runat="server" class="btn btn-md btn-primary my-2 my-sm-0" type="submit" Text="Save" Width="100px" OnClick="btnSubmit_Click" Visible="False"/>

</asp:Content>
