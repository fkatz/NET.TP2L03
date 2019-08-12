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

namespace UI.Desktop
{
    public partial class PlanForm : Form, IEntityForm<Plan>
    {
        //
        public Plan EntidadActual { get; set; }
        FormMode formMode;
        PlanLogic entities = new PlanLogic();
        public PlanForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            EspecialidadLogic espLogic = new EspecialidadLogic();
            this.cmbEspecialidad.DataSource = espLogic.GetAll();
            this.cmbEspecialidad.DisplayMember = "NombreEspecialidad";
        }

        public PlanForm(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public PlanForm(int id, FormMode formMode) : this()
        {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }

        public void GuardarDatos()
        {
            if (Validar())
            {
                this.MapearADatos();
                switch (this.formMode)
                {
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

        public void MapearADatos()
        {
            Plan oldEntity = this.EntidadActual;
            EspecialidadLogic esps = new EspecialidadLogic();
            this.EntidadActual = new Plan()
            {
                Especialidad = esps.GetOne(((Especialidad)cmbEspecialidad.SelectedItem).ID),
                Descripcion = txtDescripcion.Text
            };
            if (oldEntity != null)
            {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }

        public void MapearDeDatos()
        {
            txtDescripcion.Text = EntidadActual.Descripcion;
            txtID.Text = EntidadActual.ID.ToString();
            cmbEspecialidad.Text = EntidadActual.Especialidad.ToString();
            switch (this.formMode)
            {
                case FormMode.Modificación:
                case FormMode.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case FormMode.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public bool Validar()
        {
            bool valid = true;
            string message = "";

            if (txtDescripcion.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Año es obligatorio.";
            }
            else
            {
                try
                {
                    if (int.Parse(txtDescripcion.Text) > DateTime.Now.Year)
                    {
                        valid = false;
                        message += "\nEl Año del plan ingresado es mayor al actual.";
                    }
                    else if (int.Parse(txtDescripcion.Text) < 1970)
                    {
                        valid = false;
                        message += "\nEl Año del plan ingresado es invalido (debe estar entre 1970 y el año actual).";
                    }
                }
                catch (FormatException ef)
                {
                    valid = false;
                    message += "\nEl El Año debe ser un número entero positivo, entre 1970 y el año actual).";
                }
            }

            if (cmbEspecialidad.Text.Length == 0)
            {
                valid = false;
                message += "\nEspecialidad requerida.";
            }

            if (!valid)
            {
                MessageBox.Show("Error:" + message, "Plan inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlanesForm_Load(object sender, EventArgs e)
        {
            switch (this.formMode)
            {
                case FormMode.Alta:
                    this.Text = "Crear Plan";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Plan";
                    break;

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
        }
    }
}

