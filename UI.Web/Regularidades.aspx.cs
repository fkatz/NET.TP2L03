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
    public partial class Regularidades : WebBase
    {
        CursoLogic cursos = new CursoLogic();
        AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        int CurrentAlumnoID {
            get
            {
                return (int)ViewState["CurrentAlumno"];
            }
            set
            {
                ViewState["CurrentAlumno"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
			Authorize(Persona.TipoPersona.Bedel, true);
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("/error?m=" + "No hay curso seleccionado");
            }
            else if (!IsPostBack)
            {
                LoadGrid();
                ListItem regular = new ListItem("Regular", "1");
                ListItem libre = new ListItem("Libre", "2");
                ListItem cursante = new ListItem("Cursante", "3");
                condicionDropDownList.Items.Add(regular);
                condicionDropDownList.Items.Add(libre);
                condicionDropDownList.Items.Add(cursante);
            }

        }
        private void LoadGrid()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            gridView.DataSource = alumnos.ListByCurso(cursos.GetOne(id));
            gridView.DataBind();
        }
        private void LoadForm()
        {
            AlumnoInscripto alumno = alumnos.GetOne(CurrentAlumnoID);
            if (alumno.Condicion == AlumnoInscripto.Condiciones.Aprobado)
            {
                condicionDropDownList.Visible = false;
                aceptarButton.Visible = false;
                cancelarButton.Visible = false;
                condicionLabel.Visible = false;
                alumnoLabel.Text = "No puede modificarse la condición de un alumno ya aprobado";
            }
            else
            {
                aceptarButton.Visible = true;
                cancelarButton.Visible = true;
                condicionLabel.Visible = true;
                condicionDropDownList.Visible = true;
                alumnoLabel.Text = "Alumno: " + alumno.Alumno.LegajoYNombre;
                condicionDropDownList.SelectedValue = ((int)alumno.Condicion).ToString();
            }
        }

        private void Save()
        {
            int condicion = Convert.ToInt32(condicionDropDownList.SelectedValue);
            AlumnoInscripto alumno = alumnos.GetOne(CurrentAlumnoID);
            alumno.Condicion = (AlumnoInscripto.Condiciones)condicion;
            alumno.State = BusinessEntity.States.Modified;
            alumnos.Save(alumno);
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.RowState = DataControlRowState.Edit;
                AlumnoInscripto alumno = (AlumnoInscripto)e.Row.DataItem;
                
                ((Label)e.Row.FindControl("apnomLabel")).Text = alumno.Alumno.NombreCompleto;
                ((Label)e.Row.FindControl("legajoLabel")).Text = alumno.Alumno.Legajo.ToString();
                ((Label)e.Row.FindControl("condicionLabel")).Text = alumno.Condicion.ToString();

            }
        }


        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                gridView.SelectedIndex = index;
                CurrentAlumnoID = Convert.ToInt32(gridView.SelectedValue);
                LoadForm();
                formPanel.Visible = true;
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
        }
        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            Save();
            formPanel.Visible = false;
            LoadGrid();
        }
    }
}