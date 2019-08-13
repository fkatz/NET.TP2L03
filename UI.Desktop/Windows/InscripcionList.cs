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

namespace UI.Desktop
{
    public partial class InscripcionList : Form
    {
        private CursoLogic cursos = new CursoLogic();
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();

        private Persona currentAlumno;
        public InscripcionList(Persona alumno)
        {
            this.currentAlumno = alumno;
            InitializeComponent();
            dgvInscripciones.AutoGenerateColumns = false;
            gbxInscripciones.Text += " "+currentAlumno.NombreCompleto;
        }

        public void Listar()
        {
            this.dgvInscripciones.DataSource = cursos.ListByAño(System.DateTime.Now.Year);
            MateriaLogic materias = new MateriaLogic();
            PlanLogic planes = new PlanLogic();
            for (int i = 0; i< dgvInscripciones.RowCount; i++)
            {
                Curso curso = (Curso)dgvInscripciones.Rows[i].DataBoundItem;
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                dgvInscripciones["Especialidad", i].Value = plan.Especialidad.ToString();
                dgvInscripciones["CupoDisp", i].Value = curso.Cupo - cursos.CantInscriptos(curso);
                dgvInscripciones["Inscripto", i].Value = cursos.AlumnoIsInCurso(currentAlumno,curso);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            Curso curso = (Curso)dgvInscripciones.SelectedRows[0].DataBoundItem;
            DialogResult confirm = MessageBox.Show("Está por inscribirse al curso " + curso.ToString() + "\n¿Está seguro de que desea realizar esta operación?", "Inscripción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (confirm == DialogResult.Yes)
            {
                AlumnoInscripto alumno = new AlumnoInscripto()
                {
                    Alumno = currentAlumno,
                    Curso = curso,
                    Condicion = AlumnoInscripto.Condiciones.Cursante,
                    Nota = 0,
                    State = BusinessEntity.States.New
                };
                alumnos.Save(alumno);
                Listar();
            }
        }

        private void dgvInscripciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInscripciones.SelectedRows.Count == 1)
            {
                Curso curso = (Curso)dgvInscripciones.SelectedRows[0].DataBoundItem;
                btnInscribirse.Enabled = !cursos.AlumnoIsInCurso(currentAlumno, curso);
            }
            else btnInscribirse.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
