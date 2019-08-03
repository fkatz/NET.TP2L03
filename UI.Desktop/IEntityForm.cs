using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public enum FormMode
    {
        Alta, Baja, Modificación, Consulta
    }
    public interface IEntityForm<T>
    {
        T EntidadActual { get; set; }
        void MapearADatos();
        void MapearDeDatos();
        void GuardarDatos();
        bool Validar();
    }
}
