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
    public partial class EstadoAcademico : System.Web.UI.Page
    {
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        CursoLogic cursos = new CursoLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Alumno) != Persona.TipoPersona.Alumno)
                {
                    Response.Redirect("/Error.aspx?m=" + "Su cuenta no tiene privilegios suficientes para acceder a esta página");
                }
            }
            Persona persona = ((Usuario)Session["usuario"]).Persona;
            List<AlumnoInscripto> alumnoList = alumnos.ListByAlumno(persona);
            foreach (AlumnoInscripto alumno in alumnoList)
            {
                alumno.Curso = cursos.GetOne(alumno.Curso.ID);
            }
            gridView.DataSource = alumnoList;
            gridView.DataBind();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.RowState = DataControlRowState.Edit;
                AlumnoInscripto alumno = (AlumnoInscripto)e.Row.DataItem;
                string nota = "";
                if (alumno.Nota > 0) nota = alumno.Nota.ToString();
                ((Label)e.Row.FindControl("notaLabel")).Text = nota;
            }
        }
    }
}