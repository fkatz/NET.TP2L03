<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="gridView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Curso" HeaderText="Curso" />
            <asp:BoundField DataField="Condicion" HeaderText="Condición" />
            <asp:TemplateField HeaderText="Nota">
                <ItemTemplate>
                    <asp:Label runat="server" ID="notaLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
