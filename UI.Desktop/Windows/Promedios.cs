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
    public partial class Promedios : Form
    {
        AlumnoInscriptoLogic alumnosCursos = new AlumnoInscriptoLogic(); 

        public Promedios()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Promedios.promediosNotas.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", alumnosCursos.GetAllAsDTO()));
            this.reportViewer1.RefreshReport();
        }
    }
}
