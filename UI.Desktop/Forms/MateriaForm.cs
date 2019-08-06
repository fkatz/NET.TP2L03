using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop {
    public partial class MateriaForm : Form, IEntityForm<Materia> {
        public Materia EntidadActual { get; set; }
        FormMode formMode;
        MateriaLogic entities = new MateriaLogic();
        public MateriaForm() {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
            this.cmbPlan.DisplayMember = "Descripcion";
        }
        public MateriaForm(FormMode formMode) : this() {
            this.formMode = formMode;
        }
        public MateriaForm(int id, FormMode formMode) : this() {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void GuardarDatos() {
            if (Validar()) {
                this.MapearADatos();
                switch (this.formMode) {
                    case FormMode.Alta:
                        EntidadActual.State = BusinessEntity.States.New;
                        break;
                    case FormMode.Modificación:
                        EntidadActual.State = BusinessEntity.States.Modified;
                        break;
                    case FormMode.Baja:
                        EntidadActual.State = BusinessEntity.States.Deleted;
                        break;
                }
                entities.Save(EntidadActual);
            }
        }

        public void MapearADatos() {
            Materia oldEntity = this.EntidadActual;
            PlanLogic planes = new PlanLogic();
            this.EntidadActual = new Materia() {
                Descripcion = txtDescripcion.Text,
                Plan = planes.GetOne(((Plan)cmbPlan.SelectedItem).ID),
                HSSemanales = int.Parse(txtHsSemanales.Text),
                HSTotales = int.Parse(txtHorasTotal.Text)
            };
            if (oldEntity != null) {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }

        public void MapearDeDatos() {
            txtDescripcion.Text = EntidadActual.Descripcion;
            cmbPlan.SelectedIndex = cmbPlan.FindString(EntidadActual.Plan.Descripcion);
            txtHorasTotal.Text = EntidadActual.HSTotales.ToString();
            txtHsSemanales.Text = EntidadActual.HSSemanales.ToString();
            txtID.Text = EntidadActual.ID.ToString();
            switch (this.formMode) {
                case FormMode.Modificación:
                case FormMode.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case FormMode.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }



        public bool Validar() {
            bool valid = true;
            string message = "";
            return valid;
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            this.GuardarDatos();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void MateriaForm_Load(object sender, EventArgs e) {
            switch (this.formMode) {
                case FormMode.Alta:
                    this.Text = "Crear Materia";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Materia";
                    break;

            }
        }
    }
}
