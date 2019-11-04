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
    public partial class CargaNotaCursos : WebBase
    {
        DocenteCursoLogic docencias = new DocenteCursoLogic();
        CursoLogic cursos = new CursoLogic();
        MateriaLogic materias = new MateriaLogic();
        PlanLogic planes = new PlanLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
			Authorize(Persona.TipoPersona.Docente, true);
            LoadGrid();
        }

        private void LoadGrid()
        {
            Usuario usuario = Authenticate(true);
            List<DocenteCurso> docenciasList = docencias.ListByDocente(usuario.Persona);
            foreach(DocenteCurso docencia in docenciasList)
            {
                docencia.Curso = cursos.GetOne(docencia.Curso.ID);
            }
            gridView.DataSource = docenciasList;
            gridView.DataBind();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.RowState = DataControlRowState.Edit;
                DocenteCurso docencia = (DocenteCurso)e.Row.DataItem;
                Curso curso = cursos.GetOne(docencia.Curso.ID);
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                ((Label)e.Row.FindControl("especialidadLabel")).Text = plan.Especialidad.Descripcion;
            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Administrar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                gridView.SelectedIndex = index;
                int id = Convert.ToInt32(gridView.SelectedValue);
                Response.Redirect("/CargaNotas?id=" + id.ToString());
            }
        }
    }
}