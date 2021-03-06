﻿using Business.Entities;
using Business.Logic;
using System;

namespace UI.Web
{
    public partial class Especialidades1 : WebBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
			Authorize(Persona.TipoPersona.Administrador, true);
            LoadGrid();
        }

        private Especialidad Entity { get; set; }

        private EspecialidadLogic especialidades = new EspecialidadLogic();

        private void LoadGrid()
        {
            gridView.DataSource = especialidades.GetAll();
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
            if (formPanel.Visible)
            {
                LoadForm(SelectedID);
            }
        }

        private void LoadForm(int id)
        {
            Entity = especialidades.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
        }

        private void ClearForm()
        {
            Entity = null;
            descripcionTextBox.Text = "";
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedValue != null)
            {
                if (eliminarPanel.Visible) eliminarPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
            else
            {
                errorLabel.Text = "No ha seleccionado ninguna especialidad";
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedValue != null)
            {
                if (formPanel.Visible) formPanel.Visible = false;
                this.eliminarPanel.Visible = true;
            }
            else
            {
                errorLabel.Text = "No ha seleccionado ninguna especialidad";
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            if (eliminarPanel.Visible) eliminarPanel.Visible = false;
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
        }

        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = descripcionTextBox.Text;
        }

        private void SaveEntity(Especialidad especialidad)
        {
            especialidades.Save(especialidad);
        }

        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = especialidades.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Especialidad();
                    Entity.State = BusinessEntity.States.New;
                }
                LoadEntity(Entity);
                SaveEntity(Entity);
                LoadGrid();
                formPanel.Visible = false;
            }
        }

        protected void CancelarForm_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
        }

        protected void AceptarEliminar_Click(object sender, EventArgs e)
        {
            especialidades.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
    }
}