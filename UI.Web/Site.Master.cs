using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Authenticator.Authenticate();
            if ( usuario == null)
            {
                invitadoMenu.Visible = true;
            }
            else
            {
                logoutMenu.Visible = true;
                if (Authenticator.Authorize(usuario, Persona.TipoPersona.Administrador))
                {
                    administradorMenu.Visible = true;
                }
                if (Authenticator.Authorize(usuario, Persona.TipoPersona.Alumno))
                {
                    alumnoMenu.Visible = true;
                }
                if (Authenticator.Authorize(usuario, Persona.TipoPersona.Docente))
                {
                    docenteMenu.Visible = true;
                }
                if (Authenticator.Authorize(usuario, Persona.TipoPersona.Bedel))
                {
                    bedelMenu.Visible = true;
                }
            }
        }
protected void headerLabel_PreRender(object sender, EventArgs e)
        {
            headerLabel.Text = Page.Title;
        }
    }
}