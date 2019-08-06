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
    public partial class CurriculaList : Form
    {
        private MateriaLogic materias = new MateriaLogic();
        private EspecialidadLogic especialidades = new EspecialidadLogic();
        private PlanLogic planes = new PlanLogic();
        public CurriculaList()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
            dgvMaterias.AutoGenerateColumns = false;
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvEspecialidades.DataSource = especialidades.GetAll();
            this.dgvPlanes.DataSource = planes.GetAll();
            this.dgvMaterias.DataSource = materias.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Form entityForm;
            switch (tabControl.SelectedTab.Name)
            {
                case "tabEspecialidades":
                    entityForm = new EspecialidadForm(FormMode.Alta);
                    break;
                case "tabPlanes":
                    entityForm = new PlanForm(FormMode.Alta);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(FormMode.Alta);
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
                case "tabEspecialidades":
                    entityForm = new EspecialidadForm(((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabPlanes":
                    entityForm = new PlanForm(((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
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
                    if (tabControl.SelectedTab == tabEspecialidades)
                    {
                        List<Especialidad> array = new List<Especialidad>();
                        foreach (DataGridViewRow row in dgvEspecialidades.SelectedRows)
                        {
                            Especialidad entity = (Especialidad)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            especialidades.Save(entity);
                        }
                    }
                    else if (tabControl.SelectedTab == tabPlanes) {
                        List<Plan> array = new List<Plan>();
                        foreach (DataGridViewRow row in dgvPlanes.SelectedRows) {
                            Plan entity = (Plan)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            planes.Save(entity);
                        }
                    }

                    else if (tabControl.SelectedTab == tabMaterias) {
                        List<Materia> array = new List<Materia>();
                        foreach (DataGridViewRow row in dgvMaterias.SelectedRows) {
                            Materia entity = (Materia)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            materias.Save(entity);
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
