using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class Promedios : System.Web.UI.Page
    {
        AlumnoInscriptoLogic alumnosCursos = new AlumnoInscriptoLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}