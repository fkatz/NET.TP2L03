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
using UI.Desktop;
using UI.Desktop.Windows;

namespace UI.Desktop
{
    public partial class CursosDocenteList : Form
    {
        private int index = 0;
        private CursoLogic cursos = new CursoLogic();
        private DocenteCursoLogic docentes = new DocenteCursoLogic();

        private Persona currentDocente;
        public CursosDocenteList(Persona docente)
        {
            this.currentDocente = docente;
            InitializeComponent();
            dgvCursosDocente.AutoGenerateColumns = false;
            gbxCursosDocente.Text += " " + currentDocente.NombreCompleto;
        }

        public void Listar()
        {

            this.dgvCursosDocente.DataSource = cursos.ListByAño(System.DateTime.Now.Year);
            MateriaLogic materias = new MateriaLogic();
            PlanLogic planes = new PlanLogic();
            for (int i = 0; i < dgvCursosDocente.RowCount; i++)
            {
                Curso curso = (Curso)dgvCursosDocente.Rows[i].DataBoundItem;
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                DocenteCurso docCurso = docentes.GetOne(curso.ID);
                dgvCursosDocente["Materia", i].Value = curso.Materia;
                dgvCursosDocente["Comision", i].Value = curso.Comision;
                dgvCursosDocente["Especialidad", i].Value = plan.Especialidad.ToString();
                dgvCursosDocente["Año", i].Value = curso.Comision.AñoEspecialidad.ToString();
                dgvCursosDocente["TipoCargo", i].Value = docCurso.TipoCargo.ToString();
            }

        }    


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CursosDocenteList_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            Curso selectedCurso = (Curso)dgvCursosDocente.Rows[index].DataBoundItem;
            AlumnosCursoList form = new AlumnosCursoList(currentDocente,selectedCurso);
            form.Show();
        }

        private void dgvCursosDocente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
    }
}

