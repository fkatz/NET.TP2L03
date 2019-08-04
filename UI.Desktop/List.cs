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
    public partial class List : Form
    {
        private UsuarioLogic usuarios = new UsuarioLogic();
        private PersonaLogic personas = new PersonaLogic();
        private MateriaLogic materias = new MateriaLogic();
        private EspecialidadLogic especialidades = new EspecialidadLogic();
        private ComisionLogic comisiones = new ComisionLogic();
        private CursoLogic cursos = new CursoLogic();
        // COMPLETAR
        public List()
        {
            InitializeComponent();
            if (usuarios.GetByUsername("fkatz") == null)
            {
                usuarios.Save(new Usuario()
                {
                    NombreUsuario = "fkatz",
                    Clave = "fedefede",
                    Email = "fkatz@gmail.com",
                    Habilitado = true,
                    State = BusinessEntity.States.New
                });
            }
            dgvUsuarios.AutoGenerateColumns = false;
            dgvPersonas.AutoGenerateColumns = false;
            dgvComisiones.AutoGenerateColumns = false; ;
            dgvCursos.AutoGenerateColumns = false; ;
            dgvEspecialidades.AutoGenerateColumns = false; ;
            dgvMaterias.AutoGenerateColumns = false; ;
            dgvPlanes.AutoGenerateColumns = false; ;
        }

        public void Listar()
        {
            this.dgvPersonas.DataSource = personas.GetAll();
            this.dgvUsuarios.DataSource = usuarios.GetAll();
            this.dgvEspecialidades.DataSource = especialidades.GetAll();
            //COMPLETAR
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            if (!login.logged)
            {
                this.Dispose();
            }
            else Listar();
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
                case "tabUsuarios":
                    entityForm = new UsuarioForm(FormMode.Alta);
                    break;
                case "tabPersonas":
                    entityForm = new PersonaForm(FormMode.Alta);
                    break;
                case "tabEspecialidades":
                    entityForm = new EspecialidadForm(FormMode.Alta);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(FormMode.Alta);
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
                case "tabUsuarios":
                    entityForm = new UsuarioForm(((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabPersonas":
                    entityForm = new PersonaForm(((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabEspecialidades":
                    entityForm = new EspecialidadForm(((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabMaterias":
                    entityForm = new EspecialidadForm(((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
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
                if (tabControl.SelectedTab == tabUsuarios)
                {
                    List<Usuario> array = new List<Usuario>();
                    foreach (DataGridViewRow row in dgvUsuarios.SelectedRows)
                    {
                        Usuario entity = (Usuario)row.DataBoundItem;
                        entity.State = BusinessEntity.States.Deleted;
                        usuarios.Save(entity);
                    }
                }
                else if (tabControl.SelectedTab == tabPersonas)
                {
                    List<Persona> array = new List<Persona>();
                    foreach (DataGridViewRow row in dgvPersonas.SelectedRows)
                    {
                        Persona entity = (Persona)row.DataBoundItem;
                        entity.State = BusinessEntity.States.Deleted;
                        personas.Save(entity);
                    }
                }
                else if (tabControl.SelectedTab == tabEspecialidades) {
                    List<Especialidad> array = new List<Especialidad>();
                    foreach (DataGridViewRow row in dgvEspecialidades.SelectedRows) {
                        Especialidad entity = (Especialidad)row.DataBoundItem;
                        entity.State = BusinessEntity.States.Deleted;
                        especialidades.Save(entity);
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
                // COMPLETAR
                Listar();
            }
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            tsbEditar.Enabled = grid.SelectedRows.Count == 1;
        }
    }
}
