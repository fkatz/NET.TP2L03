<%@ Page Title="Cargar Notas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaNotasCursos.aspx.cs" Inherits="UI.Web.CargaNotaCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView CssClass="table table-striped" ID="gridView" runat="server" AutoGenerateColumns="False" OnRowCommand="gridView_RowCommand" OnRowDataBound="gridView_RowDataBound" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="Curso" HeaderText="Curso" />
             <asp:TemplateField HeaderText="Especialidad">
                <ItemTemplate>
                    <asp:Label runat="server" ID="especialidadLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField Text="Administrar" CommandName="Administrar" />
        </Columns>
    </asp:GridView>
</asp:Content>

