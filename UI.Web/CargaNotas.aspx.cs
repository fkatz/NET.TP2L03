using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class CargaNotas : WebBase
    {
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        CursoLogic cursos = new CursoLogic();
        Curso currentCurso;
        int CurrentAlumnoID
        {
            get
            {
                return (int)ViewState["CurrentAlumno"];
            }
            set
            {
                ViewState["CurrentAlumno"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {        
			Authorize(Persona.TipoPersona.Docente, true);
            
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("/error?m=" + "No hay curso seleccionado");
            }
            else if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                currentCurso = cursos.GetOne(id);
                Page.Title = "Cargar Notas - Comisión " + currentCurso.Comision.Descripcion;
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            gridView.DataSource = alumnos.ListByCurso(currentCurso);
            gridView.DataBind();
        }

        private void LoadForm()
        {
            AlumnoInscripto alumno = alumnos.GetOne(CurrentAlumnoID);
            notaTextBox.Text = alumno.Nota.ToString();
            errorLabel.Visible = false;
            alumnoLabel.Text = "Alumno: " + alumno.Alumno.LegajoYNombre;
        }

        private void Save()
        {
            AlumnoInscripto alumno = alumnos.GetOne(CurrentAlumnoID);
            alumno.Nota = Convert.ToInt32(notaTextBox.Text);
            if (alumno.Nota >= 6)
            {
                alumno.Condicion = AlumnoInscripto.Condiciones.Aprobado;
            }
            else alumno.Condicion = AlumnoInscripto.Condiciones.Libre;
            alumno.State = BusinessEntity.States.Modified;
            alumnos.Save(alumno);
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.RowState = DataControlRowState.Edit;
                AlumnoInscripto alumno = (AlumnoInscripto)e.Row.DataItem;

                ((Label)e.Row.FindControl("apnomLabel")).Text = alumno.Alumno.NombreCompleto;
                ((Label)e.Row.FindControl("legajoLabel")).Text = alumno.Alumno.Legajo.ToString();
                ((Label)e.Row.FindControl("condicionLabel")).Text = alumno.Condicion.ToString();
                ((Label)e.Row.FindControl("notaLabel")).Text = alumno.Nota.ToString();

            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                gridView.SelectedIndex = index;
                CurrentAlumnoID = Convert.ToInt32(gridView.SelectedValue);
                LoadForm();
                formPanel.Visible = true;
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
        }
        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            bool valido = false;
            try
            {
                int nota = int.Parse(notaTextBox.Text);
                if (nota < 0 || nota > 10) throw new Exception();
                valido = true;
            }
            catch
            {
                errorLabel.Visible = true;
                errorLabel.Text = "Nota inválida. Debe ser un número entero entre 0 y 10";
            }
            if (valido)
            {
                Save();
                formPanel.Visible = false;
                LoadGrid();
            }
        }
    }
}