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
using UI.Desktop.Forms;

namespace UI.Desktop
{
    public partial class AlumnosDocentesList : Form
    {
        public AlumnosDocentesList(Curso curso) :this()
        {
            this.currentCurso = curso;
            this.Text = "Administrar curso " + curso.Comision.ToString() + " " + curso.AñoCalendario.ToString();
        }
        private Curso currentCurso;
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        private DocenteCursoLogic docentes = new DocenteCursoLogic();
        public AlumnosDocentesList()
        {
            InitializeComponent();
            dgvAlumnos.AutoGenerateColumns = false;
            dgvDocentes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvDocentes.DataSource = docentes.GetAll();
            this.dgvAlumnos.DataSource = alumnos.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Form entityForm;
            switch (tabControl.SelectedTab.Name)
            {
                //case "tsbDocentes":
                    //entityForm = new DocenteForm(FormMode.Alta);
                    //break;
                case "tsbAlumnos":
                    entityForm = new AlumnoForm(FormMode.Alta,currentCurso);
                    break;
                default: throw new Exception("No tab selected");
            }
            entityForm.ShowDialog();
            Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            Form entityForm;
            switch (tabControl.SelectedTab.Name)
            {
                case "tabDocentes":
                    entityForm = new PlanForm(((Plan)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabAlumnos":
                    entityForm = new AlumnoForm(((AlumnoInscripto)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación, currentCurso);
                    break;
                //COMPLETAR
                default: throw new Exception("No tab selected");
            }
            entityForm.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Está seguro de que desea eliminar los elementos seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (confirm == DialogResult.Yes)
            {
                try {
                    if (tabControl.SelectedTab == tsbAlumnos) {
                        List<AlumnoInscripto> array = new List<AlumnoInscripto>();
                        foreach (DataGridViewRow row in dgvAlumnos.SelectedRows) {
                            AlumnoInscripto entity = (AlumnoInscripto)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            alumnos.Save(entity);
                        }
                    }

                    else if (tabControl.SelectedTab == tsbDocentes) {
                        List<DocenteCurso> array = new List<DocenteCurso>();
                        foreach (DataGridViewRow row in dgvDocentes.SelectedRows) {
                            DocenteCurso entity = (DocenteCurso)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            docentes.Save(entity);
                        }
                    }
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    switch (ex.InnerException)
                    {
                        case System.Data.Entity.Core.UpdateException ue:
                            MessageBox.Show("No se ha podido eliminar un elemento ya que está referenciado por otro elemento", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                            break;
                    }
                }
                finally
                {
                    Listar();
                }
            }
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            tsbEditar.Enabled = grid.SelectedRows.Count == 1;
        }
    }
}
