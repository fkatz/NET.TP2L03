using Business.Entities;
using Business.Logic;
using System;

namespace UI.Web
{
    public partial class Especialidades : System.Web.UI.Page
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

        private Plan Entity { get; set; }

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

        private PlanLogic planes = new PlanLogic();
        private EspecialidadLogic especialidades = new EspecialidadLogic();

        private void LoadGrid()
        {
            gridView.DataSource = planes.GetAll();
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            Entity = planes.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
            especialidadDropDownList.SelectedValue = Entity.Especialidad.ID.ToString();
        }

        private void ClearForm()
        {
            Entity = null;
            descripcionTextBox.Text = "";
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

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = descripcionTextBox.Text;
            int especialidadId;
            int.TryParse(especialidadDropDownList.SelectedValue, out especialidadId);
            plan.Especialidad = especialidades.GetOne(especialidadId);
        }

        private void SaveEntity(Plan plan)
        {
            planes.Save(plan);
        }

        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = planes.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Plan();
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
            planes.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
    }
}