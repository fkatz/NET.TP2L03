using Business.Entities;
using Business.Logic;
using System;

namespace UI.Web
{
    public partial class Asistencia : WebBase
    {
        CursoLogic cursos = new CursoLogic();
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Authorize(Persona.TipoPersona.Administrador, true);
                ReportViewer1.AsyncRendering = false;

                cursosDropDownList.DataSource = cursos.GetAll();
                cursosDropDownList.DataBind();

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", alumnos.ListByCursoAsDTO(cursosDropDownList.SelectedIndex + 1)));
                ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Fecha", DateTime.Now.Date.ToString()));
                ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Bedel", User.ToString()));
            }
        }

        protected void cursosDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = Authenticate(true);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", alumnos.ListByCursoAsDTO(cursosDropDownList.SelectedIndex + 1)));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Fecha", DateTime.Today.ToString("dd/MM/yyyy")));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Bedel", usuario.Persona.NombreCompleto ));
        }
    }
}