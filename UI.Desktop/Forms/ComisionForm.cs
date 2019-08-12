using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop {
    public partial class ComisionForm : Form, IEntityForm<Comision> {
        public Comision EntidadActual { get; set; }
        FormMode formMode;
        ComisionLogic entities = new ComisionLogic();
        public ComisionForm() {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlan.DataSource = planLogic.GetAll();
            this.cmbPlan.DisplayMember = "Descripcion";
        }
        public ComisionForm(FormMode formMode) : this() {
            this.formMode = formMode;
        }
        public ComisionForm(int id, FormMode formMode) : this() {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void MapearADatos() {
            Comision oldEntity = this.EntidadActual;
            PlanLogic planes = new PlanLogic();
            this.EntidadActual = new Comision() {
                Descripcion = txtDescripcion.Text,
                Plan = planes.GetOne(((Plan)cmbPlan.SelectedItem).ID),
                AñoEspecialidad = int.Parse(txtAño.Text),
            };
            if (oldEntity != null) {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }

        public void MapearDeDatos() {
            txtDescripcion.Text = EntidadActual.Descripcion;
            cmbPlan.SelectedIndex = cmbPlan.FindString(EntidadActual.Plan.Descripcion);
            txtAño.Text = EntidadActual.AñoEspecialidad.ToString();
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
                this.Close();
            }
        }

        public bool Validar() {
            bool valid = true;
            string message = "";
            if (txtDescripcion.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Descripción es obligatorio.";
            }
            else if (!Regex.IsMatch(txtDescripcion.Text, "[0-9]{3}"))
                {
                    valid = false;
                    message += "\nDescripción de comisión inválida (número entero de 3 cifras).";
                }

            if (txtAño.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Año Especialidad es obligatorio.";
            }
            else
            {
                try
                {
                    if (int.Parse(txtAño.Text) < 1 || int.Parse(txtAño.Text) > 5)
                    {
                        valid = false;
                        message += "\nEl Año de Especialidad debe ser un número entero entre 1 y 5.";
                    }
                }
                catch (FormatException ef)
                {
                    valid = false;
                    message += "\nEl El Año de Especialidad debe ser un número entero entre 1 y 5.";
                }
            }

            if (cmbPlan.Text.Length == 0)
            {
                valid = false;
                message += "\nPlan requerido.";
            }

            if (!valid)
            {
                MessageBox.Show("Error:" + message, "Comisión inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            this.GuardarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ComisionForm_Load(object sender, EventArgs e) {
            switch (this.formMode) {
                case FormMode.Alta:
                    this.Text = "Crear Comisión";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Comisión";
                    break;

            }
        }
    }
}
