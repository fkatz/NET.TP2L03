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
    public partial class Usuarios : System.Web.UI.Page
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
                    Response.Redirect("/Error.aspx?m="+"Su cuenta no tiene privilegios suficientes para acceder a esta página");
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
        private Usuario Entity { get; set; }

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
        private UsuarioLogic usuarios = new UsuarioLogic();
        private PersonaLogic personas = new PersonaLogic();

        private void LoadGrid()
        {
            gridView.DataSource = usuarios.GetAll();
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }
        private void LoadForm(int id)
        {
            Entity = usuarios.GetOne(id);
            nombreUsuarioTextBox.Text = Entity.NombreUsuario;
            habilitadoCheckBox.Checked = Entity.Habilitado;
            personaDropDownList.SelectedValue = Entity.Persona.ID.ToString();
            emailTextBox.Text = Entity.Email;
        }
        private void ClearForm()
        {
            Entity = null;
            nombreUsuarioTextBox.Text = "";
            habilitadoCheckBox.Checked = false;
            emailTextBox.Text = "";
            claveTextBox.Text = "";
            repetirClaveTextBox.Text = "";
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
        private void LoadEntity(Usuario usuario)
        {
            if(claveTextBox.Text.Length >0) usuario.Clave = claveTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.NombreUsuario = nombreUsuarioTextBox.Text;
            int personaID;
            int.TryParse(personaDropDownList.SelectedValue, out personaID);
            usuario.Persona = personas.GetOne(personaID);
            usuario.Habilitado = habilitadoCheckBox.Checked;
        }
        private void SaveEntity(Usuario usuario)
        {
            usuarios.Save(usuario);
        }

        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = usuarios.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new Usuario();
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
            usuarios.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }

        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
    }
}