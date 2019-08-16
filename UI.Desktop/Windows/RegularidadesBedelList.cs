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

namespace UI.Desktop.Windows {
    public partial class RegularidadesBedelList : Form {
        private CursoLogic cursos = new CursoLogic();
        MateriaLogic materias = new MateriaLogic();
        PlanLogic planes = new PlanLogic();
        public RegularidadesBedelList() {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
        }
        public void Listar() {

            this.dgvCursos.DataSource = cursos.ListByAño(DateTime.Now.Year);

            for (int i = 0; i < dgvCursos.RowCount; i++) {
                Curso curso = (Curso)dgvCursos.Rows[i].DataBoundItem;
                Materia materia = materias.GetOne(curso.Materia.ID);
                Plan plan = planes.GetOne(materia.Plan.ID);
                dgvCursos["Materia", i].Value = materia;
                dgvCursos["Comision", i].Value = curso.Comision;
                dgvCursos["Especialidad", i].Value = plan.Especialidad;
                dgvCursos["AñoEsp", i].Value = curso.Comision.AñoEspecialidad.ToString();
            }

        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void RegularidadesBedelList_Load(object sender, EventArgs e) {
            Listar();
        }

        private void btnAdministrar_Click(object sender, EventArgs e) {
            Curso selectedCurso = (Curso)dgvCursos.SelectedRows[0].DataBoundItem;
            Windows.CargaCondicionList ca = new Windows.CargaCondicionList(selectedCurso);
            ca.ShowDialog();
        }
    }
}
