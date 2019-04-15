using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripto : BusinessEntity
    {
        public string Condicion { get; set; }
        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }
        public int Nota { get; set; }
    }
}
