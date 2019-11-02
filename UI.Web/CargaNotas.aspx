<%@ Page Title="Cargar Notas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaNotas.aspx.cs" Inherits="UI.Web.CargaNotas" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView CssClass="table table-striped" ID="gridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="gridView_RowDataBound" OnRowCommand="gridView_RowCommand" DataKeyNames="ID">
        <Columns>
            <asp:TemplateField HeaderText="Apellido y Nombre">
                <ItemTemplate>
                    <asp:Label runat="server" ID="apnomLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Legajo">
                <ItemTemplate>
                    <asp:Label runat="server" ID="legajoLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Condición">
                <ItemTemplate>
                    <asp:Label runat="server" ID="condicionLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nota">
                <ItemTemplate>
                    <asp:Label runat="server" ID="notaLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField Text="Editar" CommandName="Editar" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="formPanel" runat="server" Visible="false">
        <asp:Label ID="alumnoLabel" runat="server" Text="Alumno:"></asp:Label>
        <br />
        <asp:Label ID="notaLabel" runat="server" Text="Nota:"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="notaTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="errorLabel" runat="server" Text="Error" Visible="false"></asp:Label>
        <br />
        <asp:Button CssClass="btn btn-outline-primary" ID="cancelarButton" runat="server" Text="Cancelar" OnClick="cancelarButton_Click" />
        <asp:Button CssClass="btn btn-outline-primary" ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click" />
    </asp:Panel>
</asp:Content>
