<%@ Page Title="Administrar Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView CssClass="table table-striped" ID="gridView" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            OnSelectedIndexChanged="gridView_SelectedIndexChanged"
            SelectedRowStyle-BackColor="LightGray">
            <Columns>
                <asp:BoundField DataField="Comision" HeaderText="Comision" ReadOnly="True" SortExpression="Comision" />
                <asp:BoundField DataField="Materia" HeaderText="Materia" ReadOnly="True" SortExpression="Materia" />
                <asp:BoundField DataField="AñoCalendario" HeaderText="Año" ReadOnly="True" SortExpression="Año" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" ReadOnly="True" SortExpression="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="LightGray" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:Button CssClass="btn btn-outline-primary" ID="editarButton" runat="server" Text="Editar" OnClick="editarButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="eliminarButton" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" CausesValidation="false"/>
            <asp:Button CssClass="btn btn-outline-primary" ID="alumnosButton" runat="server" OnClick="alumnosButton_Click" Text="Alumnos" />
            <asp:Button CssClass="btn btn-outline-primary" ID="DocentesButton" runat="server" OnClick="DocentesButton_Click" Text="Docentes" />
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="ComisionLabel" runat="server" Text="Comision: "></asp:Label>
            <asp:DropDownList ID="comisionDropDownList" runat="server" DataSourceID="comisionesDatasource" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
            <br />
            <asp:ObjectDataSource ID="comisionesDatasource" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.ComisionLogic"></asp:ObjectDataSource>
            <asp:Label ID="materiaLabel" runat="server" Text="Materia: "></asp:Label>
            <asp:DropDownList ID="materiaDropDownList" runat="server" DataSourceID="materiasDatasource" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
            <br />
            <asp:ObjectDataSource ID="materiasDatasource" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.MateriaLogic"></asp:ObjectDataSource>
            <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
            <asp:TextBox ID="cupoTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="cupoTextBox" ErrorMessage="El cupo es inválido" ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cupoTextBox" ErrorMessage="El cupo es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="añoCalendarioLabel" runat="server" Text="Año Calendario: "></asp:Label>
            <asp:TextBox ID="añoCalendarioTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="añoCalendarioTextBox" ErrorMessage="El Año Calendario deben ser un número entero positivo de 4 cifras" ValidationExpression="[12][0-9]{3}">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="añoCalendarioTextBox" ErrorMessage="El campo Año Calendario del Curso es requerido">*</asp:RequiredFieldValidator>
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
