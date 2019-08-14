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

namespace UI.Desktop {
    public partial class CondicionesAlumnos : Form {
        Curso selectedCurso;
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        public CondicionesAlumnos(Curso curso) {
            InitializeComponent();
            this.selectedCurso = curso;
            dgvAlumnos.AutoGenerateColumns = false;
            gbxAlumnosCurso.Text += this.selectedCurso.Materia + " " + this.selectedCurso.Comision;
            
        }
        public void Listar() {
            List<AlumnoInscripto> alumnoList = alumnos.ListByCurso(this.selectedCurso);
            this.dgvAlumnos.DataSource = alumnoList;

            for (int i = 0; i < dgvAlumnos.RowCount; i++) {
                Persona alumno = alumnoList[i].Alumno;
                dgvAlumnos["Alumno", i].Value = alumno.NombreCompleto;
                dgvAlumnos["Condicion", i].Value = alumnoList[i].Condicion.ToString();
                dgvAlumnos["Nota", i].Value = alumnoList[i].Nota.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CondicionesAlumnos_Load(object sender, EventArgs e) {
            Listar();
        }

        private void btnCondicion_Click(object sender, EventArgs e) {
            AlumnoInscripto selectedAlumno = (AlumnoInscripto)dgvAlumnos.SelectedRows[0].DataBoundItem;
            editCondicion form = new editCondicion(selectedAlumno);
            form.FormClosing += new FormClosingEventHandler(this.editCondicion_FormClosing);
            form.Show();
        }

        private void editCondicion_FormClosing(object sender, FormClosingEventArgs e) {
            Listar();
        }
    }
}
