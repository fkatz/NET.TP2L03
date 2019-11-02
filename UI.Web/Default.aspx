<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Button ID="promediosButton" runat="server" Height="30px" OnClick="promediosBoton_Click" Text="Consultar Promedios de Notas" />
    <asp:Button ID="planillaButton" runat="server" Height="30px" Text="Generar Planilla de Asistencia Diara" />
</asp:Content>
