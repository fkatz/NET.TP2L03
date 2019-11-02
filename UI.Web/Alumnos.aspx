<%@ Page Title="Administrar Alumnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="UI.Web.Alumnos" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:Label ID="cupoLabel" runat="server" CssClass="h4" Text="Cupo"></asp:Label>
        <asp:GridView CssClass="table table-striped" ID="gridView" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            OnSelectedIndexChanged="gridView_SelectedIndexChanged"
            SelectedRowStyle-BackColor="LightGray">
            <Columns>
                <asp:BoundField DataField="Alumno" HeaderText="Alumno" ReadOnly="True" SortExpression="Alumno" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" ReadOnly="True" SortExpression="Condicion" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" ReadOnly="True" SortExpression="Nota" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="LightGray" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:Button CssClass="btn btn-outline-primary" ID="editarButton" runat="server" Text="Editar" OnClick="editarButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="eliminarButton" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" CausesValidation="false"/>
            <asp:Label ID="errorLabel" runat="server" Text="Mensaje de error 3."></asp:Label>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="legajoLabel" runat="server" Text="Legajo Alumno: "></asp:Label>
            <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="El legajo es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
            <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="notaTextBox" ErrorMessage="El campo nota del Alumno es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="condicionLabel" runat="server" Text="Condicion: "></asp:Label>
            <asp:DropDownList ID="condicionDropDownList" runat="server" >
            </asp:DropDownList>
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
