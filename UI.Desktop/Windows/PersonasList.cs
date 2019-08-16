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
    public partial class PersonasList : Form
    {
        private PersonaLogic personas = new PersonaLogic();
        public PersonasList()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvPersonas.DataSource = personas.GetAll();
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
            entityForm = new Forms.PersonaForm(FormMode.Alta);
            entityForm.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            Form entityForm;
            entityForm = new Forms.PersonaForm(((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
            entityForm.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Está seguro de que desea eliminar los elementos seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (confirm == DialogResult.Yes)
            {
                try {
                        List<Persona> array = new List<Persona>();
                        foreach (DataGridViewRow row in dgvPersonas.SelectedRows)
                        {
                            Persona entity = (Persona)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            personas.Save(entity);
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
