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
    public partial class Inscripciones : System.Web.UI.Page
    {
        CursoLogic cursos = new CursoLogic();
        MateriaLogic materias = new MateriaLogic();
        PlanLogic planes = new PlanLogic();
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Docente) != Persona.TipoPersona.Docente)
                {
                    Response.Redirect("/Error.aspx?m=" + "Su cuenta no tiene privilegios suficientes para acceder a esta página");
                }
            }
            LoadGrid();
        }
        public void LoadGrid()
        {
            gridView.DataSource = cursos.ListByAño(DateTime.Now.Year);
            gridView.DataBind();

        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.RowState = DataControlRowState.Edit;
                Curso curso = (Curso)e.Row.DataItem;
                Usuario usuario = (Usuario)Session["usuario"];

                if (curso.Cupo - cursos.CantInscriptos(curso) > 0 && !cursos.AlumnoIsInCurso(usuario.Persona,curso))
                {
                    ((Label)e.Row.FindControl("materiaLabel")).Text = curso.Materia.Descripcion;
                    ((Label)e.Row.FindControl("comisionLabel")).Text = curso.Comision.Descripcion;
                    Materia materia = materias.GetOne(curso.Materia.ID);
                    Plan plan = planes.GetOne(materia.Plan.ID);
                    ((Label)e.Row.FindControl("especialidadLabel")).Text = plan.Especialidad.Descripcion;
                }
                else
                {
                    e.Row.Visible = false;
                }

            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribirse")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                gridView.SelectedIndex = index;
                int id = Convert.ToInt32(gridView.SelectedValue);
                Curso curso = cursos.GetOne(id);
                if (curso.Cupo - cursos.CantInscriptos(curso) > 0)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    AlumnoInscripto alumno = new AlumnoInscripto()
                    {
                        Alumno = usuario.Persona,
                        Curso = curso,
                        Condicion = AlumnoInscripto.Condiciones.Cursante,
                        Nota = 0
                    };
                    alumnos.Save(alumno);
                    errorLabel.Text = "Inscripción realizada";
                    errorLabel.Visible = true;
                    LoadGrid();
                }
                else
                {
                    errorLabel.Text = "Error: No hay cupo disponible";
                    errorLabel.Visible = true;

                }
            }
        }
    }
}