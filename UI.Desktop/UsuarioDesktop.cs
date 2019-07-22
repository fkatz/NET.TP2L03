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
using Data.Database;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual;
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public UsuarioDesktop(int id, FormMode formMode) : this()
        {
            UsuarioAdapter adaptador = new UsuarioAdapter();
            this.UsuarioActual = adaptador.GetOne(id);
            this.formMode = formMode;
        }
        public override void MapearADatos()
        {
            this.UsuarioActual = new Usuario()
            {
                Nombre = this.txtNombre.Text,
                Apellido = this.txtApellido.Text,
                NombreUsuario = this.txtUsuario.Text,
                Email = this.txtEmail.Text,
            };
            if (this.formMode == FormMode.Modificación) this.UsuarioActual.ID = Int32.Parse(this.txtId.Text);
        }
        public override void MapearDeDatos()
        {
            this.txtApellido.Text = UsuarioActual.Apellido;
            this.txtNombre.Text = UsuarioActual.Nombre;
            this.txtEmail.Text = UsuarioActual.Email;
            this.txtUsuario.Text = UsuarioActual.NombreUsuario;
            this.txtId.Text = UsuarioActual.ID.ToString();
            this.chkHabilitado.Enabled = UsuarioActual.Habilitado;
            switch (this.formMode)
            {
                case FormMode.Modificación:
                case FormMode.Alta: this.btnAceptar.Text = "Guardar";
                    break;
                case FormMode.Baja: this.btnAceptar.Text = "Eliminar";
                    break;
            }



        }
        public override void GuardarDatos()
        {

        }
        public override bool Validar()
        {
            return false;
        }
    }
}
