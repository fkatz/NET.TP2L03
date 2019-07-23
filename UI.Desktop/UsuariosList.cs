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
    public partial class UsuariosList : Form
    {
        private UsuarioLogic usuarios = new UsuarioLogic();

        public UsuariosList()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            usuarios.GetAll();
            this.dgvUsuarios.DataSource = usuarios.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            if (!login.logged)
            {
                this.Dispose();
            }
            else Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioForm usDesk = new UsuarioForm(ApplicationForm.FormMode.Alta);
            usDesk.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            UsuarioForm usDesk = new UsuarioForm(((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID,ApplicationForm.FormMode.Modificación);
            usDesk.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Está seguro de que desea eliminar los usuarios seleccionados?", "Eliminar usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (confirm == DialogResult.Yes)
            {
                List<Usuario> array = new List<Usuario>();
                foreach (DataGridViewRow row in dgvUsuarios.SelectedRows)
                {
                    Usuario user = (Usuario)row.DataBoundItem;
                    user.State = BusinessEntity.States.Deleted;
                    usuarios.Save(user);
                }
                Listar();
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            this.tsbEditar.Enabled = dgvUsuarios.SelectedRows.Count == 1;
        }
    }
}
