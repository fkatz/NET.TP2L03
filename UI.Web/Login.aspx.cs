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
        string redirect;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["redirect"]!=null) 
            {
                redirect = Request.QueryString["redirect"];
            }
            else redirect = "/";
            if(Authenticator.Authenticate() != null){

            }
        }

        protected void IngresarButton_Click(object sender, EventArgs e)
        {
            bool authenticated;
            Usuario usuario = Authenticator.Authenticate(UsuarioTextBox.Text, ClaveTextBox.Text, out authenticated);
            if (authenticated && usuario.Habilitado)
            {
                Response.Redirect(redirect);
            }
            if(!authenticated)
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