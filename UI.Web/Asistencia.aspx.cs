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
            Authorize(Persona.TipoPersona.Bedel, true);
            if (!IsPostBack)
            {
                Usuario usuario = Authenticate(false);
                ReportViewer1.AsyncRendering = false;

                cursosDropDownList.DataSource = cursos.GetAll();
                cursosDropDownList.DataBind();

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", alumnos.ListByCursoAsDTO(cursosDropDownList.SelectedIndex + 1)));
                ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Fecha", DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year));
                ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Bedel", usuario.Persona.NombreCompleto));
            }
        }

        protected void cursosDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", alumnos.ListByCursoAsDTO(cursosDropDownList.SelectedIndex + 1)));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Fecha", DateTime.Today.Day+"/"+DateTime.Today.Month+"/"+DateTime.Today.Year));
            ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("Bedel", usuario.Persona.NombreCompleto ));
        }
    }
}