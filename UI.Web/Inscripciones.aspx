<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="gridView" runat="server" OnRowDataBound="gridView_RowDataBound">
        <Columns>
            <asp:ButtonField Text="Button" />
            <asp:TemplateField HeaderText="Materia">
                <ItemTemplate>
                    <asp:Label runat="server" ID="materiaLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comisión">
                <ItemTemplate>
                    <asp:Label runat="server" ID="comisionLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Especialidad">
                <ItemTemplate>
                    <asp:Label runat="server" ID="especialidadLabel"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
