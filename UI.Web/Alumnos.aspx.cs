﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Alumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Administrador) != Persona.TipoPersona.Administrador)
                {
                    Response.Redirect("/Error.aspx?m="+"Su cuenta no tiene privilegios suficientes para acceder a esta página");
                }

                LoadGrid();
            }
        }


        public enum FormModes
        {
            Alta,
            Modificacion
        }
        public FormModes FormMode
        {
            get
            {
                return (FormModes)ViewState["FormMode"];
            }
            set
            {
                ViewState["FormMode"] = value;
            }
        }
        private Comision Entity { get; set; }

        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else return 0;
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get { return SelectedID != 0; }
        }
        private ComisionLogic comisiones = new ComisionLogic();
        private PlanLogic planes = new PlanLogic();

        private void LoadGrid()
        {

            gridView.DataSource = comisiones.GetAll();
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }
        private void LoadForm(int id)
        {
            Entity = comisiones.GetOne(id);
            planDropDownList.SelectedValue = Entity.Plan.ID.ToString();
            descripcionTextBox.Text = Entity.Descripcion;
            añoEspecialidadTextBox.Text = Entity.AñoEspecialidad.ToString();
        }
        private void ClearForm()
        {
            Entity = null;
            añoEspecialidadTextBox.Text = "";
            descripcionTextBox.Text = "";
            planDropDownList.SelectedIndex = -1;
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            if (eliminarPanel.Visible) eliminarPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Modificacion;
            this.LoadForm(this.SelectedID);
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            if (formPanel.Visible) formPanel.Visible = false;
            this.eliminarPanel.Visible = true;
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            if (eliminarPanel.Visible) eliminarPanel.Visible = false;
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
        }
        
        private void LoadEntity(Comision comision)
        {
            if (descripcionTextBox.Text.Length > 0 && añoEspecialidadTextBox.Text.Length > 0 && planDropDownList.SelectedItem != null)
                comision.Descripcion = descripcionTextBox.Text;
                comision.AñoEspecialidad = int.Parse(añoEspecialidadTextBox.Text);
                int idPlan = int.Parse(planDropDownList.SelectedValue);
                comision.Plan = planes.GetOne(idPlan);
        }

        private void SaveEntity(Comision comision)
        {
            comisiones.Save(comision);
        }
        
        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = comisiones.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Comision();
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
            comisiones.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
        
    }
}