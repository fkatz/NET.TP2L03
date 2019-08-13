using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.Windows
{
    public partial class AlumnosCursoList : Form
    {
        private CursoLogic cursos = new CursoLogic();
        private DocenteCursoLogic docentes = new DocenteCursoLogic();
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();

        private int index = 0;
        private Persona currentDocente;
        private Curso selectedCurso;
        public AlumnosCursoList(Persona docente, Curso curso)
        {
            this.currentDocente = docente;
            this.selectedCurso = curso;
            InitializeComponent();
            dgvAlumnosCurso.AutoGenerateColumns = false;
            gbxAlumnosCurso.Text += " " + currentDocente.NombreCompleto;
        }

        public void Listar()
        {
            List<AlumnoInscripto> alumnoList = alumnos.ListByCursoAndCondicion(selectedCurso,"Regular","Cursante");
            foreach(AlumnoInscripto alumno in alumnoList)
            {
                alumno.Curso = cursos.GetOne(alumno.Curso.ID);            
            }
            this.dgvAlumnosCurso.DataSource = alumnoList;

            for (int i = 0; i < dgvAlumnosCurso.RowCount; i++)
            {
                Persona alumno = alumnoList[i].Alumno;
                dgvAlumnosCurso["Alumno", i].Value = alumno.NombreCompleto;
                dgvAlumnosCurso["Condicion", i].Value = alumnoList[i].Condicion.ToString();
                dgvAlumnosCurso["Nota", i].Value = alumnoList[i].Nota.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlumnosCursoList_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void editNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            Listar();
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            AlumnoInscripto selectedAlumno = (AlumnoInscripto)dgvAlumnosCurso.Rows[index].DataBoundItem;
            editNota form = new editNota(selectedAlumno);
            form.FormClosing += new FormClosingEventHandler(this.editNota_FormClosing);
            form.Show();
        }

        private void dgvAlumnosCurso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
    }
}
