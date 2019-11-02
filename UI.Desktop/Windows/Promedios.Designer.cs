using Microsoft.Reporting.WinForms;

namespace UI.Desktop.Windows
{
    partial class Promedios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be Dispose()d; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Location = new System.Drawing.Point(5, 5);
            this.reportViewer2.Name = "ReportViewer";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(650, 454);
            this.reportViewer2.TabIndex = 0;
            this.reportViewer2.Reset();
            this.reportViewer2.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer2.LocalReport;
            localReport.ReportPath = "promediosNotas.rdlc";
            ReportDataSource datasource = new ReportDataSource();
            datasource.Name = "DataSet1";
            datasource.Value = alumnosCursos.GetAllAsDTO();
            localReport.DataSources.Add(datasource);
            this.reportViewer2.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer2.RefreshReport();
            // Promedios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 464);
            this.Controls.Add(this.reportViewer2);
            this.Name = "Promedios";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Promedios";
            this.ResumeLayout(false);

        }

        #endregion

        protected ReportViewer reportViewer2;
    }
}