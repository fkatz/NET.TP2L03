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
using System.Text.RegularExpressions;

namespace UI.Desktop {
    public partial class EspecialidadForm : Form, IEntityForm<Especialidad> {
        public Especialidad EntidadActual { get; set; }
        FormMode formMode;
        EspecialidadLogic entities = new EspecialidadLogic();
        public EspecialidadForm() {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }

        public EspecialidadForm(FormMode formMode) : this() {
            this.formMode = formMode;
        }
        public EspecialidadForm(int id, FormMode formMode) : this() {
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
                this.Close();
            }
        }

        public void MapearADatos() {
            Especialidad oldEntity = this.EntidadActual;
            this.EntidadActual = new Especialidad() {
                Descripcion=txtDescripcion.Text
            };
            if (oldEntity != null) {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }

        public void MapearDeDatos() {
            txtDescripcion.Text = EntidadActual.Descripcion;
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
            if (txtDescripcion.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Descripción es obligatorio.";
            }
            else if (!Regex.IsMatch(txtDescripcion.Text, "[a-zA-Z][a-zA-Z0-9]{2,}([ ][a-zA-Z0-9]*)*"))
                {
                    valid = false;
                    message += "\nDescripción de especialidad inválida.";
                }



            if (!valid)
            {
                MessageBox.Show("Error:" + message, "Especialidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            this.GuardarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void EspecialidadesForm_Load(object sender, EventArgs e) {
            switch (this.formMode) {
                case FormMode.Alta:
                    this.Text = "Crear Especialidad";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Especialidad";
                    break;

            }
        }
    }
}
