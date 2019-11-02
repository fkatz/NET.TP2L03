<%@ Page Title="Administrar Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView CssClass="table table-striped" ID="gridView" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            OnSelectedIndexChanged="gridView_SelectedIndexChanged"
            SelectedRowStyle-BackColor="LightGray">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="LightGray" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:Button CssClass="btn btn-outline-primary" ID="editarButton" runat="server" Text="Editar" OnClick="editarButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="eliminarButton" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" CausesValidation="false"/>
        </asp:Panel><br />
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="descripcionLabel" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="El Email es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:ValidationSummary ID="ValidationSummary" ShowSummary="true" runat="server" />
            <br />
            <asp:Button CssClass="btn btn-outline-primary" ID="CancelarForm" runat="server" Text="Cancelar" OnClick="CancelarForm_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="AceptarForm" runat="server" Text="Aceptar" OnClick="AceptarForm_Click" />
        </asp:Panel>
                <asp:Panel ID="eliminarPanel" Visible="false" runat="server">
            <asp:Label ID="eliminarLabel" runat="server" Text="¿Está seguro de que desea eliminar este elemento?"></asp:Label>
            <br />
            <asp:Button CssClass="btn btn-outline-primary" ID="CancelarEliminar" runat="server" Text="Cancelar" OnClick="CancelarEliminar_Click" />
            <asp:Button CssClass="btn btn-outline-primary" ID="AceptarEliminar" runat="server" Text="Aceptar" OnClick="AceptarEliminar_Click" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
