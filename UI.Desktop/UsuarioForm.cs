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
    public partial class UsuarioForm : ApplicationForm
    {
        public Usuario UsuarioActual;
        UsuarioLogic users = new UsuarioLogic();
        private UsuarioForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }
        public UsuarioForm(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public UsuarioForm(int id, FormMode formMode) : this()
        {
            this.UsuarioActual = users.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public override void MapearADatos()
        {
            Usuario oldUsr = this.UsuarioActual;
            this.UsuarioActual = new Usuario()
            {
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                NombreUsuario = this.txtUsuario.Text,
                Email = this.txtEmail.Text,
                Habilitado = this.chkHabilitado.Checked
            };
            UsuarioActual.Clave = (this.txtClave.Text.Length > 0) ? this.txtClave.Text : oldUsr.Clave;
            if (this.formMode == FormMode.Modificación) this.UsuarioActual.ID = Int32.Parse(this.txtId.Text);
        }
        public override void MapearDeDatos()
        {
            this.txtApellido.Text = UsuarioActual.Apellido;
            this.txtNombre.Text = UsuarioActual.Nombre;
            this.txtEmail.Text = UsuarioActual.Email;
            this.txtUsuario.Text = UsuarioActual.NombreUsuario;
            this.txtId.Text = UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = UsuarioActual.Habilitado;
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
        public override void GuardarDatos()
        {
            if (Validar())
            {
                this.MapearADatos();
                switch (this.formMode)
                {
                    case FormMode.Alta:
                        UsuarioActual.State = BusinessEntity.States.New;
                        break;
                    case FormMode.Modificación:
                        UsuarioActual.State = BusinessEntity.States.Modified;
                        break;
                    case FormMode.Baja:
                        UsuarioActual.State = BusinessEntity.States.Deleted;
                        break;
                }
                users.Save(UsuarioActual);
            }
        }
        public override bool Validar()
        {
            bool valid = true;
            string message = "";
            if (!Regex.IsMatch(txtEmail.Text, "^[a-zA-Z0-9]+([a-zA-Z0-9_]+[a-zA-Z0-9])@[a-zA-Z0-9]+\\.[a-zA-Z0-9]+$"))
            {
                valid = false;
                message += "\nEmail inválido.";
            }
            if (!Regex.IsMatch(txtUsuario.Text, "^[a-zA-Z0-9][a-zA-Z0-9_]{2,}[a-zA-Z0-9]$"))
            {
                valid = false;
                message += "\nNombre de usuario inválido.";
            }
            else
            {
                Usuario savedUser = users.GetByUsername(txtUsuario.Text);
                if (savedUser != null && UsuarioActual != null && UsuarioActual.ID != savedUser.ID)
                {
                    valid = false;
                    message += "\nYa existe un usuario con ese nombre de usuario.";
                }
            }
            if (!Regex.IsMatch(UsuarioActual.Nombre, "^[A-ZÁ-ÚÑ][a-zá-úñ]+( [A-ZÁ-ÚÑ][a-zá-úñ]+)*$"))
            {
                valid = false;
                message += "\nNombre inválido.";
            }
            if (!Regex.IsMatch(UsuarioActual.Apellido, "^[A-ZÁ-ÚÑ][a-zá-úñ]+( [A-ZÁ-ÚÑ][a-zá-úñ]+)*$"))
            {
                valid = false;
                message += "\nApellido inválido.";
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
            this.Dispose();
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
                    this.Text = "Crear Usuario";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Usuario";
                    break;

            }
        }
    }
}
