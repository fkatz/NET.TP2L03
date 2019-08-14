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
        MateriaLogic materias = new MateriaLogic();
        PlanLogic planes = new PlanLogic();

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

            this.dgvCursosDocente.DataSource = docentes.ListByDocente(currentDocente);

            for (int i = 0; i < dgvCursosDocente.RowCount; i++)
            {
                DocenteCurso docCurso = (DocenteCurso)dgvCursosDocente.Rows[i].DataBoundItem;
                Curso curso = cursos.GetOne(docCurso.Curso.ID);
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                dgvCursosDocente["Materia", i].Value = materia;
                dgvCursosDocente["Comision", i].Value = curso.Comision;
                dgvCursosDocente["Especialidad", i].Value = plan.Especialidad;
                dgvCursosDocente["AñoEsp", i].Value = curso.Comision.AñoEspecialidad.ToString();
                dgvCursosDocente["AñoCal", i].Value = curso.AñoCalendario.ToString();
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
            DocenteCurso selectedDocCurso = (DocenteCurso)dgvCursosDocente.Rows[index].DataBoundItem;
            AlumnosCursoList form = new AlumnosCursoList(selectedDocCurso);
            form.Show();
        }

        private void dgvCursosDocente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DocenteCurso selectedDocCurso = (DocenteCurso)dgvCursosDocente.Rows[index].DataBoundItem;
            if(selectedDocCurso.Curso.AñoCalendario > DateTime.Now.Year)
            {
                btnAdministrar.Enabled = false;
            }
            else
            {
                btnAdministrar.Enabled = true;
                if (selectedDocCurso.Curso.AñoCalendario < DateTime.Now.Year)
                {
                    btnAdministrar.Text = "Ver Notas";
                }
                else
                {
                    btnAdministrar.Text = "Administrar Notas";
                }
            }

        }
    }
}

