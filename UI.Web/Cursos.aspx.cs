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
    public partial class Cursos : WebBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
			Authorize(Persona.TipoPersona.Administrador, true);
            LoadGrid();
        }
   
        private Curso Entity { get; set; }

        private CursoLogic cursos = new CursoLogic();
        private MateriaLogic materias = new MateriaLogic();
        private ComisionLogic comisiones = new ComisionLogic();

        private void LoadGrid()
        {

            gridView.DataSource = cursos.GetAll();
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
            Entity = cursos.GetOne(id);
            comisionDropDownList.SelectedValue = Entity.Comision.ID.ToString();
            materiaDropDownList.SelectedValue = Entity.Materia.ID.ToString();
            cupoTextBox.Text = Entity.Cupo.ToString();
            añoCalendarioTextBox.Text = Entity.AñoCalendario.ToString();
        }
        private void ClearForm()
        {
            Entity = null;
            añoCalendarioTextBox.Text = "";
            cupoTextBox.Text = "";
            comisionDropDownList.SelectedIndex = -1;
            materiaDropDownList.SelectedIndex = -1;
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
                errorLabel.Text = " No ha seleccionado ningun curso";
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
                errorLabel.Text = " No ha seleccionado ningun curso";
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            if (eliminarPanel.Visible) eliminarPanel.Visible = false;
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
        }
        
        private void LoadEntity(Curso curso)
        {
            if (cupoTextBox.Text.Length > 0 && añoCalendarioTextBox.Text.Length > 0 && comisionDropDownList.SelectedItem != null && materiaDropDownList.SelectedItem != null)
                curso.Cupo = int.Parse(cupoTextBox.Text);
                curso.AñoCalendario = int.Parse(añoCalendarioTextBox.Text);
                int idComision = int.Parse(comisionDropDownList.SelectedValue);
                curso.Comision = comisiones.GetOne(idComision);
                int idMateria = int.Parse(materiaDropDownList.SelectedValue);
                curso.Materia = materias.GetOne(idMateria);
        }

        private void SaveEntity(Curso curso)
        {
            try
            {
                cursos.Save(curso);
            }
            catch(Exception e)
            {
                Response.Redirect("/Error.aspx?m=" + e.Message, true);
            }
        }
        
        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = cursos.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Curso();
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
            cursos.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }

        protected void alumnosButton_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedValue != null)
            {
                Response.Redirect("/Alumnos.aspx?idCurso=" + SelectedID);
            }
            else
            {
                errorLabel.Text = " No ha seleccionado ningun curso";
            }
}

        protected void DocentesButton_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedValue != null)
            {
                Response.Redirect("/Docentes.aspx?idCurso=" + SelectedID);
            }
            else
            {
                errorLabel.Text = " No ha seleccionado ningun curso";
            }
}
    }
}