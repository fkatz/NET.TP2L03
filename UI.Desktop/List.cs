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
        private PlanLogic planes = new PlanLogic();
        // COMPLETAR
        public List()
        {
            InitializeComponent();
            if (usuarios.FindByUsername("fkatz") == null)
            {
                Usuario usr = new Usuario()
                {
                    NombreUsuario = "fkatz",
                    Clave = "fedefede",
                    Email = "fkatz@gmail.com",
                    Habilitado = true,
                    State = BusinessEntity.States.New
                };
                usuarios.Save(usr);
                if (personas.FindByLegajo(44744) == null)
                {
                    personas.Save(new Persona()
                    {
                        Nombre = "Federico",
                        Apellido = "Katzaroff",
                        Legajo = 44744,
                        Tipo = Persona.TipoPersona.Alumno|Persona.TipoPersona.Administrador,
                        Direccion = "Guaraní 3048",
                        Telefono = "4398771",
                        FechaNacimiento = new DateTime(1995,5,16),
                        Usuario = usr,
                        State = BusinessEntity.States.New
                    });
                }
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
            this.dgvPlanes.DataSource = planes.GetAll();
            this.dgvMaterias.DataSource = materias.GetAll();
            this.dgvComisiones.DataSource = comisiones.GetAll();
            this.dgvCursos.DataSource = cursos.GetAll();
            //COMPLETAR
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
                case "tabUsuarios":
                    entityForm = new UsuarioForm(FormMode.Alta);
                    break;
                case "tabPersonas":
                    entityForm = new PersonaForm(FormMode.Alta);
                    break;
                case "tabEspecialidades":
                    entityForm = new EspecialidadForm(FormMode.Alta);
                    break;
                case "tabPlanes":
                    entityForm = new PlanForm(FormMode.Alta);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(FormMode.Alta);
                    break;
                case "tabComisiones":
                    entityForm = new ComisionForm(FormMode.Alta);
                    break;
                case "tabCursos":
                    entityForm = new CursoForm(FormMode.Alta);
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
                case "tabPlanes":
                    entityForm = new PlanForm(((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabComisiones":
                    entityForm = new ComisionForm(((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabCursos":
                    entityForm = new CursoForm(((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
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
                    else if (tabControl.SelectedTab == tabEspecialidades)
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
                    else if (tabControl.SelectedTab == tabComisiones) {
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
                    // COMPLETAR
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
                // COMPLETAR
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
