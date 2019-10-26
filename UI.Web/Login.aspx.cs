using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioLogic usuarios = new UsuarioLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IngresarButton_Click(object sender, EventArgs e)
        {
            Usuario usuario = usuarios.FindByUsername(UsuarioTextBox.Text);
            if (usuario != null && usuario.Clave == ClaveTextBox.Text && usuario.Habilitado)
            {
                Session["usuario"] = usuario;
                Response.Redirect("/");
            }
            if(usuario.Clave != ClaveTextBox.Text || usuario == null)
            {
                ErrorLabel.Text = "El usuario o contraseña son incorrectos";
            }
            else if(usuario != null && !usuario.Habilitado)
            {
                ErrorLabel.Text = "Su cuenta no ha sido habilitada";
            }
            ErrorLabel.Visible = true;
        }
    }
}