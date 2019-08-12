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
    public partial class InscripcionForm : Form
    {
        private CursoLogic cursos = new CursoLogic();
        private Persona currentAlumno;
        public InscripcionForm(Persona alumno)
        {
            this.currentAlumno = alumno;
            InitializeComponent();
            dgvInscripciones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvInscripciones.DataSource = cursos.GetAll();
            MateriaLogic materias = new MateriaLogic();
            PlanLogic planes = new PlanLogic();
            for (int i = 0; i< dgvInscripciones.RowCount; i++)
            {
                Curso curso = (Curso)dgvInscripciones.Rows[i].DataBoundItem;
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                dgvInscripciones["Especialidad", i].Value = plan.Especialidad.ToString();

                dgvInscripciones["CupoDisp", i].Value = curso.Cupo-cursos.CantInscriptos(curso);
                dgvInscripciones["CupoDisp", i].Value = curso.Cupo - cursos.CantInscriptos(curso);
                dgvInscripciones["CupoDisp", i].Value = "Inscribirse";

            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dgvInscripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Curso curso = (Curso)dgvInscripciones.Rows[e.RowIndex].DataBoundItem;

                MessageBox.Show(curso.ToString());
            }
        }
    }
}
