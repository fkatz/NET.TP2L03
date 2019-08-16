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
    public partial class CursadaList : Form
    {
        private ComisionLogic comisiones = new ComisionLogic();
        private CursoLogic cursos = new CursoLogic();
        public CursadaList()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvComisiones.DataSource = comisiones.GetAll();
            this.dgvCursos.DataSource = cursos.GetAll();
        }

        private void OnLoad(object sender, EventArgs e)
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
                case "tabComisiones":
                    entityForm = new Forms.ComisionForm(FormMode.Alta);
                    break;
                case "tabCursos":
                    entityForm = new Forms.CursoForm(FormMode.Alta);
                    break;
                //COMPLETAR
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
                case "tabComisiones":
                    entityForm = new Forms.ComisionForm(((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabCursos":
                    entityForm = new Forms.CursoForm(((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
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
                    if (tabControl.SelectedTab == tabComisiones) {
                        List<Comision> array = new List<Comision>();
                        foreach (DataGridViewRow row in dgvComisiones.SelectedRows) {
                            Comision entity = (Comision)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            comisiones.Save(entity);
                        }
                    }
                    else if (tabControl.SelectedTab == tabCursos)
                    {
                        List<Curso> array = new List<Curso>();
                        foreach (DataGridViewRow row in dgvCursos.SelectedRows)
                        {
                            Curso entity = (Curso)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            cursos.Save(entity);
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
            tsbAlumDoc.Enabled = grid.SelectedRows.Count == 1;
            tsbEditar.Enabled = grid.SelectedRows.Count == 1;
            tsbEliminar.Enabled = grid.SelectedRows.Count >= 1;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl.SelectedTab == tabCursos)
            {
                tsSeparator.Visible = true;
                tsbAlumDoc.Visible = true;
            }
            else
            {
                tsSeparator.Visible = false;
                tsbAlumDoc.Visible = false;
            }
        }

        private void tsbAlumDoc_Click(object sender, EventArgs e)
        {
            Form entityList = new AlumnosDocentesList(((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem));
            entityList.ShowDialog();
            Listar();
        }
    }
}
