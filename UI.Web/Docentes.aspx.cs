using Business.Entities;
using Business.Logic;
using System;

namespace UI.Web
{
    public partial class Docentes : WebBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authorize(Persona.TipoPersona.Administrador, true);

            cargoDropDownList.DataSource = Enum.GetNames(typeof(DocenteCurso.TiposCargos));
            cargoDropDownList.DataBind();

            LoadGrid();
        }

        private DocenteCurso Entity { get; set; }
        private DocenteCursoLogic docentes = new DocenteCursoLogic();
        private PersonaLogic personas = new PersonaLogic();
        private CursoLogic cursos = new CursoLogic();
        private Curso CurrentCurso = new Curso();

        private void LoadGrid()
        {
            int idCurso = int.Parse(Request.QueryString["idCurso"]);
            CurrentCurso = cursos.GetOne(idCurso);
            gridView.DataSource = docentes.ListByCurso(CurrentCurso);
            gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
            if (formPanel.Visible)
            {
                LoadForm(SelectedID);
            }
        }
        private void LoadForm(int id)
        {
            Entity = docentes.GetOne(id);
            cargoDropDownList.SelectedValue = Entity.TipoCargo.ToString();
            legajoTextBox.Text = Entity.Docente.Legajo.ToString();
        }

        private void ClearForm()
        {
            Entity = null;
            legajoTextBox.Text = "";
            cargoDropDownList.SelectedIndex = -1;
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

        private void LoadEntity(DocenteCurso docente)
        {
            DocenteCurso.TiposCargos c = new DocenteCurso.TiposCargos();
            switch (cargoDropDownList.SelectedItem.Text)
            {
                case "Adjunto":
                    c = DocenteCurso.TiposCargos.Adjunto;
                    break;
                case "Ayudante":
                    c = DocenteCurso.TiposCargos.Ayudante;
                    break;
                case "Titular":
                    c = DocenteCurso.TiposCargos.Titular;
                    break;
            }

            if (legajoTextBox.Text.Length > 0 && cargoDropDownList.SelectedItem != null)
                docente.Docente = personas.FindByLegajo(int.Parse(legajoTextBox.Text));
            docente.TipoCargo = c;
            docente.Curso = CurrentCurso;
        }

        private void SaveEntity(DocenteCurso docente)
        {
            docentes.Save(docente);
        }

        protected void AceptarForm_Click(object sender, EventArgs e)
        {
            Validate();
            if (Page.IsValid)
            {
                if (FormMode == FormModes.Modificacion)
                {
                    Entity = docentes.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                }
                else
                {
                    Entity = new DocenteCurso();
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
            docentes.Delete(SelectedID);
            LoadGrid();
            eliminarPanel.Visible = false;
        }
        protected void CancelarEliminar_Click(object sender, EventArgs e)
        {
            eliminarPanel.Visible = false;
        }
    }
}