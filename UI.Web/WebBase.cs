using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public abstract class WebBase : System.Web.UI.Page
    {   
        private UsuarioLogic usuarios = new UsuarioLogic();
        protected Usuario Authenticate(bool redirect = false){
            Usuario usuario = Authenticator.Authenticate();
            if (usuario == null && redirect)
            {
                Response.Redirect("/login.aspx?redirect="+Request.CurrentExecutionFilePath,true);
            }
            return usuario;
        }
        protected bool Authorize(Persona.TipoPersona tipo, bool redirect = false){
            Usuario usuario = Authenticate(redirect);
            bool authorized = Authenticator.Authorize(usuario, tipo);
            if(!authorized && redirect)
            {
                Response.Redirect("/Error.aspx?m=" + "Su cuenta no tiene privilegios suficientes para acceder a esta página.",true);
            }
            return authorized;
        }
        protected enum FormModes
        {
            Alta,
            Modificacion
        }
        protected FormModes FormMode
        {
            get
            {
                return (FormModes)ViewState["FormMode"];
            }
            set
            {
                ViewState["FormMode"] = value;
            }
        }

        protected int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else return 0;
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get { return SelectedID != 0; }
        }
    }
}