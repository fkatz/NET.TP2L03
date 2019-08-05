using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop
{
    public partial class PersonaForm : Form, IEntityForm<Persona>
    {
        public Persona EntidadActual { get; set; }
        FormMode formMode;
        PersonaLogic entities = new PersonaLogic();
        private PersonaForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            UsuarioLogic usrLogic = new UsuarioLogic();
            this.cmbUsuario.DataSource = usrLogic.GetAll();
            this.cmbUsuario.DisplayMember = "NombreUsuario";
        }
        public PersonaForm(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public PersonaForm(int id, FormMode formMode) : this()
        {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void MapearADatos()
        {
            Persona oldEntity = this.EntidadActual;
            Persona.TipoPersona tp = 0;
            if (chkTipoAlumno.Checked) tp |= Persona.TipoPersona.Alumno;
            if (chkTipoDocente.Checked) tp |= Persona.TipoPersona.Docente;
            if (chkTipoNoDocente.Checked) tp |= Persona.TipoPersona.NoDocente;
            UsuarioLogic users = new UsuarioLogic();
            this.EntidadActual = new Persona()
            {
                Tipo = tp,
                Legajo = int.Parse(txtLegajo.Text),
                Usuario = users.GetOne(((Usuario)cmbUsuario.SelectedItem).ID),
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                FechaNacimiento = dtpFechaNac.Value.Date
            };
            if(oldEntity != null)
            {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }
        public void MapearDeDatos()
        {
            // mapping
            chkTipoAlumno.Checked = (EntidadActual.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno;
            chkTipoDocente.Checked = (EntidadActual.Tipo & Persona.TipoPersona.Docente) == Persona.TipoPersona.Docente;
            chkTipoNoDocente.Checked = (EntidadActual.Tipo & Persona.TipoPersona.NoDocente) == Persona.TipoPersona.NoDocente;
            txtLegajo.Text = EntidadActual.Legajo.ToString();
            cmbUsuario.SelectedIndex = cmbUsuario.FindString(EntidadActual.Usuario.NombreUsuario);
            txtApellido.Text = EntidadActual.Apellido;
            txtNombre.Text = EntidadActual.Nombre;
            txtTelefono.Text = EntidadActual.Telefono;
            txtDireccion.Text = EntidadActual.Direccion;
            dtpFechaNac.Value = EntidadActual.FechaNacimiento;
            txtID.Text = EntidadActual.ID.ToString();
            switch (this.formMode)
            {
                case FormMode.Modificación:
                case FormMode.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case FormMode.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }
        public void GuardarDatos()
        {
            if (Validar())
            {
                this.MapearADatos();
                switch (this.formMode)
                {
                    case FormMode.Alta:
                        EntidadActual.State = BusinessEntity.States.New;
                        break;
                    case FormMode.Modificación:
                        EntidadActual.State = BusinessEntity.States.Modified;
                        break;
                    case FormMode.Baja:
                        EntidadActual.State = BusinessEntity.States.Deleted;
                        break;
                }
                entities.Save(EntidadActual);
                this.Dispose();
            }
        }
        public bool Validar()
        {
            bool valid = true;
            string message = "";
            try
            {
                int.Parse(txtLegajo.Text);
            }
            catch(FormatException ef)
            {
                valid = false;
                message += "\nEl legajo debe ser un número entero.";
            }
            if (!Regex.IsMatch(txtNombre.Text, "^[A-ZÁ-ÚÑ][a-zá-úñ]+( [A-ZÁ-ÚÑ][a-zá-úñ]+)*$"))
            {
                valid = false;
                message += "\nNombre inválido.";
            }
            if (!Regex.IsMatch(txtApellido.Text, "^[A-ZÁ-ÚÑ][a-zá-úñ]+( [A-ZÁ-ÚÑ][a-zá-úñ]+)*$"))
            {
                valid = false;
                message += "\nApellido inválido.";
            }
            if (!Regex.IsMatch(txtTelefono.Text, "^[0-9]+$") || txtTelefono.Text.Length <1)
            {
                valid = false;
                message += "\nTelefono inválido.";
            }
            if (txtDireccion.Text.Length < 1)
            {
                valid = false;
                message += "\nDirección inválida.";
            }
            if (!valid)
            {
                MessageBox.Show("Error:" + message, "Usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            switch (this.formMode)
            {
                case FormMode.Alta:
                    this.Text = "Crear Persona";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Persona";
                    break;

            }
        }
    }
}
