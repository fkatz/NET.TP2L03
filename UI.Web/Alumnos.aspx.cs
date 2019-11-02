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
    public partial class Alumnos : WebBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idCurso"] == null)
            {
                Response.Redirect("/error?m=" + "No hay curso seleccionado");
            }
            Authorize(Persona.TipoPersona.Administrador, true);
            if (!IsPostBack)
            {
                condicionDropDownList.DataSource = new string[] { "Regular", "Libre", "Aprobado", "Cursante" };
                condicionDropDownList.DataBind();
            }

            int idCurso = int.Parse(Request.QueryString["idCurso"]);
            CurrentCurso = cursos.GetOne(idCurso);
            Page.Title = "Administrar Alumnos - Comisión " + CurrentCurso.Comision.Descripcion;
            int inscriptos = cursos.CantInscriptos(CurrentCurso);
            cupoLabel.Text = "Cupo: " + inscriptos + "/" + CurrentCurso.Cupo;
            if (inscriptos > CurrentCurso.Cupo) cupoLabel.CssClass += " error";
            LoadGrid();
        }

        private AlumnoInscripto Entity { get; set; }
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        private PersonaLogic personas = new PersonaLogic();
        private CursoLogic cursos = new CursoLogic();
        private Curso CurrentCurso = new Curso();
        
        private void LoadGrid()
        {

            gridView.DataSource = alumnos.ListByCurso(CurrentCurso);
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
            Entity = alumnos.GetOne(id);
            condicionDropDownList.SelectedValue = Entity.Condicion.ToString();
            legajoTextBox.Text = Entity.Alumno.Legajo.ToString();
            notaTextBox.Text = Entity.Nota.ToString();
        }
        private void ClearForm()
        {
            Entity = null;
            notaTextBox.Text = "";
            legajoTextBox.Text = "";
            condicionDropDownList.SelectedIndex = -1;
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
        
        private void LoadEntity(AlumnoInscripto alumno)
        {
            AlumnoInscripto.Condiciones condicion = new AlumnoInscripto.Condiciones();
            switch (condicionDropDownList.SelectedValue)
            {
                case "Regular":
                    condicion = AlumnoInscripto.Condiciones.Regular;
                    break;
                case "Libre":
                    condicion = AlumnoInscripto.Condiciones.Libre;
                    break;
                case "Aprobado":
                    condicion = AlumnoInscripto.Condiciones.Aprobado;
                    break;
                case "Cursante":
                    condicion = AlumnoInscripto.Condiciones.Cursante;
                    break;
            }

            if (legajoTextBox.Text.Length > 0 && notaTextBox.Text.Length > 0 && condicionDropDownList.SelectedItem != null)
                alumno.Alumno = personas.FindByLegajo(int.Parse(legajoTextBox.Text));
                alumno.Nota = int.Parse(notaTextBox.Text);
                alumno.Condicion = condicion;
                alumno.Curso = CurrentCurso; 
        }

        private void SaveEntity(AlumnoInscripto alumno)
        {
            alumnos.Save(alumno);
        }
        
        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = alumnos.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new AlumnoInscripto();
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
            alumnos.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }

    }
}