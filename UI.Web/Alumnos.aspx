﻿<%@ Page Title="Alumnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="UI.Web.Alumnos" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" 
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
            <asp:Button ID="editarButton" runat="server" Text="Editar" OnClick="editarButton_Click" CausesValidation="false"/>
            <asp:Button ID="eliminarButton" runat="server" Text="Eliminar" OnClick="eliminarButton_Click" CausesValidation="false"/>
            <asp:Button ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" CausesValidation="false"/>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion es inválida" ValidationExpression="[0-9]{3}">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion es requerida">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="añoEspecialidadLabel" runat="server" Text="Año Especialidad: "></asp:Label>
            <asp:TextBox ID="añoEspecialidadTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="añoEspecialidadTextBox" ErrorMessage="El Año de Especialidad deben ser un número entero positivo menor o igual a 5" ValidationExpression="[12345]">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="añoEspecialidadTextBox" ErrorMessage="El campo Año de Especialidad de la Comision es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="planDropDownList" runat="server" DataSourceID="PlanesDatasource" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
            <br />
            <asp:ObjectDataSource ID="PlanesDatasource" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic"></asp:ObjectDataSource>
            <asp:ValidationSummary ID="ValidationSummary" ShowSummary="true" runat="server" />
            <br />
            <asp:Button ID="CancelarForm" runat="server" Text="Cancelar" OnClick="CancelarForm_Click" CausesValidation="false"/>
            <asp:Button ID="AceptarForm" runat="server" Text="Aceptar" OnClick="AceptarForm_Click" />
        </asp:Panel>
                <asp:Panel ID="eliminarPanel" Visible="false" runat="server">
            <asp:Label ID="eliminarLabel" runat="server" Text="¿Está seguro de que desea eliminar este elemento?"></asp:Label>
            <br />
            <asp:Button ID="CancelarEliminar" runat="server" Text="Cancelar" OnClick="CancelarEliminar_Click" />
            <asp:Button ID="AceptarEliminar" runat="server" Text="Aceptar" OnClick="AceptarEliminar_Click" />
        </asp:Panel>
    </asp:Panel>

</asp:Content>
