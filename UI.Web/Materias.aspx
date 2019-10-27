<%@ Page Title="Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ID" 
            OnSelectedIndexChanged="gridView_SelectedIndexChanged"
            SelectedRowStyle-BackColor="LightGray">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Materia" ReadOnly="True" SortExpression="Descripcion" />
                <asp:BoundField DataField="Plan" HeaderText="Plan" ReadOnly="True" SortExpression="Plan" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" ReadOnly="True" SortExpression="HSSemanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" ReadOnly="True" SortExpression="HSTotales" />
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
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion es inválida" ValidationExpression="[a-zA-Z][a-zA-Z0-9]{2,}([ ][a-zA-Z0-9]*)*">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripcion es requerida">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas Semanales: "></asp:Label>
            <asp:TextBox ID="hsSemanalesTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="hsSemanalesTextBox" ErrorMessage="Las Horas Semanales deben ser un número entero positivo" ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="hsSemanalesTextBox" ErrorMessage="El campo Horas Semanales de la Materia es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas Totales: "></asp:Label>
            <asp:TextBox ID="hsTotalesTextBox" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="hsTotalesTextBox" ErrorMessage="Las Horas Totales deben ser un número entero positivo" ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="hsTotalesTextBox" ErrorMessage="El campo Horas Totales de la Materia es requerido">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="planDropDownList" runat="server" DataSourceID="PlanesDatasource" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
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
