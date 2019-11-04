using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop.Windows
{
    public partial class ListadoAsistencia : Form
    {
        AlumnoInscriptoLogic alumnosCursos = new AlumnoInscriptoLogic();
        CursoLogic cursos;
        Persona persona;
        public ListadoAsistencia(Persona persona)
        {
            this.persona = persona;
            InitializeComponent();
            cursos = new CursoLogic();
            cbxCurso.DataSource = cursos.GetAll();
            cbxCurso.DisplayMember = "descripcion";
            cbxCurso.ValueMember = "ID";
            cbxCurso.SelectedIndex = 1;

            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCurso.SelectedIndex != -1)
            {
                reportViewer2.LocalReport.DataSources.Clear();
                this.reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", alumnosCursos.ListByCursoAsDTO(((Curso)cbxCurso.SelectedItem).ID)  ) );
                reportViewer2.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Today.ToString()));
                reportViewer2.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Bedel", persona.NombreCompleto));
                reportViewer2.LocalReport.Refresh();
                this.reportViewer2.RefreshReport();
            }
        }
    }
}
