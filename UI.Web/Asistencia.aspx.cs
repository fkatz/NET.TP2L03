using Business.Logic;
using System;

namespace UI.Web
{
    public partial class Asistencia : System.Web.UI.Page
    {
        CursoLogic cursos = new CursoLogic();
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.AsyncRendering = false;
                cursosDropDownList.DataSource = cursos.GetAll();
                cursosDropDownList.DataBind();
            }
        }

        protected void cursosDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", alumnos.ListByCursoAsDTO(cursosDropDownList.SelectedIndex + 1)));
        }
    }
}