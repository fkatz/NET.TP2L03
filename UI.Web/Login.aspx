<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="UsuarioLabel" runat="server" Text="Usuario"></asp:Label>
    <br />
    <asp:TextBox ID="UsuarioTextBox" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="ClaveLabel" runat="server" Text="Contraseña"></asp:Label>
    <br />
    <asp:TextBox ID="ClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="ErrorLabel" runat="server" Text="Error" Visible="false"></asp:Label>
    <br />
    <asp:Button CssClass="btn btn-outline-primary" ID="IngresarButton" runat="server" Text="Ingresar" OnClick="IngresarButton_Click" />
</asp:Content>
