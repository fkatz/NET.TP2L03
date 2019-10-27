using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Materias : WebBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Authorize(Persona.TipoPersona.Administrador, true);
            LoadGrid();
        }

        private Materia Entity { get; set; }
        private MateriaLogic materias = new MateriaLogic();
        private PlanLogic planes = new PlanLogic();

        private void LoadGrid()
        {

            gridView.DataSource = materias.GetAll();
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
            Entity = materias.GetOne(id);
            planDropDownList.SelectedValue = Entity.Plan.ID.ToString();
            descripcionTextBox.Text = Entity.Descripcion;
            hsSemanalesTextBox.Text = Entity.HSSemanales.ToString();
            hsTotalesTextBox.Text = Entity.HSTotales.ToString();
        }
        private void ClearForm()
        {
            Entity = null;
            hsSemanalesTextBox.Text = "";
            descripcionTextBox.Text = "";
            hsTotalesTextBox.Text = "";
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
        
        private void LoadEntity(Materia materia)
        {
            if (descripcionTextBox.Text.Length > 0 && hsSemanalesTextBox.Text.Length > 0 && hsTotalesTextBox.Text.Length > 0 && planDropDownList.SelectedItem != null)
                materia.Descripcion = descripcionTextBox.Text;
                materia.HSSemanales = int.Parse(hsSemanalesTextBox.Text);
                materia.HSTotales = int.Parse(hsTotalesTextBox.Text);
                int idPlan = int.Parse(planDropDownList.SelectedValue);
                materia.Plan = planes.GetOne(idPlan);
        }

        private void SaveEntity(Materia materia)
        {
            materias.Save(materia);
        }
        
        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = materias.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Materia();
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
            materias.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
        
    }
}