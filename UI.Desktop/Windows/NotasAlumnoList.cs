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

namespace UI.Desktop.Windows
{
    public partial class NotasAlumnoList : Form
    {
        private CursoLogic cursos = new CursoLogic();
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();

        private Persona currentAlumno;
        public NotasAlumnoList(Persona alumno)
        {
            this.currentAlumno = alumno;
            InitializeComponent();
            dgvInscripciones.AutoGenerateColumns = false;
            gbxInscripciones.Text += " "+currentAlumno.NombreCompleto;
        }

        public void Listar()
        {
            List<AlumnoInscripto> alumnoList = alumnos.ListByAlumno(currentAlumno);
            foreach(AlumnoInscripto alumno in alumnoList)
            {
                alumno.Curso = cursos.GetOne(alumno.Curso.ID);
            }
            this.dgvInscripciones.DataSource = alumnoList;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
