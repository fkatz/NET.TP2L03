using Business.Entities;
using Business.Logic;
using System;
using System.Globalization;

namespace UI.Web
{
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if ((usuario.Persona.Tipo & Persona.TipoPersona.Administrador) != Persona.TipoPersona.Administrador)
                {
                    Response.Redirect("/Error.aspx?m=" + "Su cuenta no tiene privilegios suficientes para acceder a esta página");
                }

                LoadGrid();
            }
        }
        public enum FormModes
        {
            Alta,
            Modificacion
        }
        public FormModes FormMode
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
        private Persona Entity { get; set; }

        private int SelectedID
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

        private PersonaLogic personas = new PersonaLogic();

        private void LoadGrid()
        {
            gridView.DataSource = personas.GetAll();
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            Entity = personas.GetOne(id);
            nombreTextBox.Text = Entity.Nombre;
            legajoTextBox.Text = Entity.Legajo.ToString();
            DireccionTextBox.Text = Entity.Direccion;
            apellidoTextBox.Text = Entity.Apellido;
            FechaNacTextBox.Text = Entity.FechaNacimiento.ToString("yyyy-MM-dd");
            TelefonoTextBox.Text = Entity.Telefono;
            chboxAlumno1.Checked = (Entity.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno;
            chboxDocente.Checked = (Entity.Tipo & Persona.TipoPersona.Docente) == Persona.TipoPersona.Docente;
            chboxNoDocente.Checked = (Entity.Tipo & Persona.TipoPersona.NoDocente) == Persona.TipoPersona.NoDocente;
            chboxPreceptor.Checked = (Entity.Tipo & Persona.TipoPersona.Bedel) == Persona.TipoPersona.Bedel;
            chboxAdministrador.Checked = (Entity.Tipo & Persona.TipoPersona.Administrador) == Persona.TipoPersona.Administrador;

        }
        private void ClearForm()
        {
            Entity = null;
            nombreTextBox.Text = "";
            chboxDocente.Checked = false;
            chboxAlumno1.Checked = false;
            chboxAdministrador.Checked = false;
            chboxNoDocente.Checked = false;
            chboxPreceptor.Checked = false;
            TelefonoTextBox.Text = "";
            FechaNacTextBox.Text = "";
            legajoTextBox.Text = "";
            apellidoTextBox.Text = "";
            DireccionTextBox.Text = "";
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            if (eliminarPanel.Visible) eliminarPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Modificacion;
            this.LoadForm(this.SelectedID);
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            if (formPanel.Visible) formPanel.Visible = false;
            this.eliminarPanel.Visible = true;
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            if (eliminarPanel.Visible) eliminarPanel.Visible = false;
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
        }
        private void LoadEntity(Persona persona)
        {
            persona.Nombre = nombreTextBox.Text;
            persona.Apellido = apellidoTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.FechaNacimiento = DateTime.Parse(FechaNacTextBox.Text, new CultureInfo("en-CA"));
            persona.Legajo = Convert.ToInt32(legajoTextBox.Text);
            Persona.TipoPersona tp = 0;
            if (chboxAlumno1.Checked) tp |= Persona.TipoPersona.Alumno;
            if (chboxDocente.Checked) tp |= Persona.TipoPersona.Docente;
            if (chboxNoDocente.Checked) tp |= Persona.TipoPersona.NoDocente;
            if (chboxPreceptor.Checked) tp |= Persona.TipoPersona.Bedel;
            if (chboxAdministrador.Checked) tp |= Persona.TipoPersona.Administrador;
            persona.Tipo = tp;
        }
        private void SaveEntity(Persona persona)
        {
            personas.Save(persona);
        }

        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = personas.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Persona();
                    Entity.State = BusinessEntity.States.New;
                }
                LoadEntity(Entity);
                SaveEntity(Entity);
                LoadGrid();
                formPanel.Visible = false;
            }
        }

        protected void CancelarForm_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
        }

        protected void AceptarEliminar_Click(object sender, EventArgs e)
        {
            personas.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
    }
}