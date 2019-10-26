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

namespace UI.Desktop.Forms
{
    public partial class UsuarioForm : Form, IEntityForm<Usuario>
    {
        public Usuario EntidadActual { get; set; }
        FormMode formMode;
        UsuarioLogic entities = new UsuarioLogic();
        PersonaLogic personas = new PersonaLogic();
        private UsuarioForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            this.cmbPersona.DataSource = personas.GetAll();
            this.cmbPersona.DisplayMember = "LegajoYNombre";
            this.cmbPersona.ValueMember = "ID";
        }
        public UsuarioForm(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public UsuarioForm(int id, FormMode formMode) : this()
        {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void MapearADatos()
        {
            Usuario oldUsr = this.EntidadActual;

            this.EntidadActual = new Usuario()
            {
                NombreUsuario = this.txtUsuario.Text,
                Email = this.txtEmail.Text,
                Habilitado = this.chkHabilitado.Checked,
                Persona = personas.GetOne(((Persona)cmbPersona.SelectedItem).ID)
            };              
            EntidadActual.Clave = (this.txtClave.Text.Length > 0) ? this.txtClave.Text : oldUsr.Clave;
            if (this.formMode == FormMode.Modificación) this.EntidadActual.ID = Int32.Parse(this.txtId.Text);
        }
        public void MapearDeDatos()
        {
            this.txtEmail.Text = EntidadActual.Email;
            this.txtUsuario.Text = EntidadActual.NombreUsuario;
            this.txtId.Text = EntidadActual.ID.ToString();
            this.chkHabilitado.Checked = EntidadActual.Habilitado;
            cmbPersona.SelectedIndex = cmbPersona.FindString(EntidadActual.Persona.LegajoYNombre);
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
                this.Close();

            }
        }
        public bool Validar()
        {
            bool valid = true;
            string message = "";
            if (txtEmail.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Email es obligatorio.";
            }
            else if (!Regex.IsMatch(txtEmail.Text, "^[a-zA-Z0-9]+([a-zA-Z0-9_]+[a-zA-Z0-9])@[a-zA-Z0-9]+\\.[a-zA-Z0-9]+$"))
                {
                    valid = false;
                    message += "\nEmail inválido.";
                }

            if (txtUsuario.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Usuario es obligatorio.";
            }
            else if (!Regex.IsMatch(txtUsuario.Text, "^[a-zA-Z0-9][a-zA-Z0-9_]{2,}[a-zA-Z0-9]$"))
                {
                    valid = false;
                    message += "\nNombre de usuario inválido.";
                }
                else
                    {
                        Usuario savedUser = entities.FindByUsername(txtUsuario.Text);
                        if (savedUser != null && EntidadActual != null && EntidadActual.ID != savedUser.ID)
                        {
                            valid = false;
                            message += "\nYa existe un usuario con ese nombre de usuario.";
                        }
                    }

            if (this.formMode == FormMode.Alta && txtClave.Text.Length == 0)
            {
                valid = false;
                message += "\nContraseña requerida.";
            }
            if (txtClave.Text.Length > 0 && txtConfirmarClave.Text != txtClave.Text)
            {
                valid = false;
                message += "\nLas contraseñas ingresadas no coinciden.";
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
            this.Close();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            switch (this.formMode)
            {
                case FormMode.Alta:
                    this.Text = "Crear Usuario";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Usuario";
                    break;

            }
        }
    }
}
