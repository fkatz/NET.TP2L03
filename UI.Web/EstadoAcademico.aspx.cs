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
    public partial class EstadoAcademico : WebBase
    {
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        CursoLogic cursos = new CursoLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
			Authorize(Persona.TipoPersona.Alumno, true);

            Persona persona = Authenticate(true).Persona;
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