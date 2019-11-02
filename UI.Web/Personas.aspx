<%@ Page Title="Administrar Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView CssClass="table table-striped" DataKeyNames="ID" ID="gridView" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="gridView_SelectedIndexChanged" SelectedRowStyle-BackColor="LightGray">
            <SelectedRowStyle BackColor="LightGray" />
            <Columns>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:Button CssClass="btn btn-outline-primary" ID="editarButton" runat="server" Text="Editar" OnClick="editarButton_Click" CausesValidation="false" />
        <asp:Button CssClass="btn btn-outline-primary" ID="eliminarButton" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" CausesValidation="false" />
        <asp:Button CssClass="btn btn-outline-primary" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" CausesValidation="false" />
        <asp:Label ID="errorLabel" runat="server" Text="Mensaje de error 3"></asp:Label>
    </asp:Panel><br />
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="emailLabel" runat="server" Text="Legajo: "></asp:Label>
        <asp:TextBox ID="legajoTextBox" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="El Legajo es Inválido" ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="El  Legajo es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="tipoLabel" runat="server" Text="Tipo:"></asp:Label>
        <asp:CheckBox ID="chboxAlumno1" runat="server" Text="Alumno" />
        <asp:CheckBox ID="chboxDocente" runat="server" Text="Docente" />
        <asp:CheckBox ID="chboxNoDocente" runat="server" Text="No Docente" />
        <asp:CheckBox ID="chboxPreceptor" runat="server" Text="Preceptor" />
        <asp:CheckBox ID="chboxAdministrador" runat="server" Text="Administrador" />
        <br />
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre sólo puede contener letras" ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El campo Nombre es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El nombre de usuario sólo puede contener letras, números, guiones y guiones bajos" ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El campo Nombre de Usuario es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="TelefonoLabel" runat="server" Text="Telefono:"></asp:Label>
        <asp:TextBox ID="TelefonoTextBox" runat="server" TextMode="Phone"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TelefonoTextBox" ErrorMessage="El telefono solo puede tener numeros" ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TelefonoTextBox" ErrorMessage="El campo telefono es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="DireccionLabel" runat="server" Text="Dirección:"></asp:Label>
        <asp:TextBox ID="DireccionTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="DireccionTextBox" ErrorMessage="La dirección solo puede tener letras y numeros" ValidationExpression="^[A-Za-z0-9\s]+$">*</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El campo direccion es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="FechaNacLabel" runat="server" Text="Fecha Nacimiento:"></asp:Label>
        <asp:TextBox ID="FechaNacTextBox" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FechaNacTextBox" ErrorMessage="El campo direccion es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary" ShowSummary="true" runat="server" />
        <br />
        <asp:Button CssClass="btn btn-outline-primary" ID="CancelarForm" runat="server" Text="Cancelar" OnClick="CancelarForm_Click" CausesValidation="false" />
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
