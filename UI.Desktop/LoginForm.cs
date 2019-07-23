using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class LoginForm : Form
    {
        public Boolean logged = false;
        public Usuario loggedUser;
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            this.CancelButton = btnCancelar;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Login();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void Login()
        {
            UsuarioAdapter usuarios = new UsuarioAdapter();
            Usuario user = usuarios.GetByUsername(txtUser.Text);
            if (user == null || user.Clave != txtPassword.Text)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
            else
            {
                this.logged = true;
                this.loggedUser = user;
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
    }
}
