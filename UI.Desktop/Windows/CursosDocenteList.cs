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

namespace UI.Desktop.Windows
{
    public partial class CursosDocenteList : Form
    {
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
                dgvCursosDocente["Cargo", i].Value = docCurso.TipoCargo.ToString();
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
            DocenteCurso selectedDocCurso = (DocenteCurso)dgvCursosDocente.SelectedRows[0].DataBoundItem;
            CargaNotasList form = new CargaNotasList(selectedDocCurso);
            form.Show();
        }

        private void dgvCursosDocente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DocenteCurso selectedDocCurso = (DocenteCurso)dgvCursosDocente.Rows[e.RowIndex].DataBoundItem;
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

