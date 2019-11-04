using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class Promedios : WebBase
    {
        AlumnoInscriptoLogic alumnosCursos = new AlumnoInscriptoLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize(Persona.TipoPersona.Administrador, true);

        }
    }
}