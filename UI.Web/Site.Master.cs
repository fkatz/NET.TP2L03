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
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario == null)
            {
                invitadoMenu.Visible = true;
            }
            else
            {
                logoutMenu.Visible = true;
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Administrador) == Persona.TipoPersona.Administrador)
                {
                    administradorMenu.Visible = true;
                }
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno)
                {
                    alumnoMenu.Visible = true;
                }
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Docente) == Persona.TipoPersona.Docente)
                {
                    docenteMenu.Visible = true;
                }
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Bedel) == Persona.TipoPersona.Bedel)
                {
                    bedelMenu.Visible = true;
                }
            }
        }
    }
}