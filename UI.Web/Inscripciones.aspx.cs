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

        protected void Page_Load(object sender, EventArgs e)
        {
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
                ((Label)e.Row.FindControl("materiaLabel")).Text = curso.Materia.Descripcion;
                ((Label)e.Row.FindControl("comisionLabel")).Text = curso.Comision.Descripcion;
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                ((Label)e.Row.FindControl("especialidadLabel")).Text = plan.Especialidad.Descripcion;
            }
        }
    }
}