﻿using Business.Entities;
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
    public partial class Login : Form
    {
        public Boolean logged = false;
        public Usuario loggedUser;
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            this.CancelButton = btnCancelar;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.DoLogin();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DoLogin()
        {
            UsuarioAdapter usuarios = new UsuarioAdapter();
            Usuario user = usuarios.FindByUsername(txtUser.Text);
            if (user == null || user.Clave != txtPassword.Text)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
            else if (user != null && !user.Habilitado)
            {
                MessageBox.Show("Su cuenta no está habilitada");
            }
            else
            {
                this.logged = true;
                this.loggedUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
