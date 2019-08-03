using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class AlumnoInscriptoLogic : BusinessLogic
    {
        Data.Database.AlumnoInscriptoAdapter AlumnoInscriptoData { get; set; }
        public AlumnoInscriptoLogic()
        {
            AlumnoInscriptoData = new Data.Database.AlumnoInscriptoAdapter();
        }
        public AlumnoInscripto GetOne(int ID)
        {
            return AlumnoInscriptoData.GetOne(ID);
        }
        public List<AlumnoInscripto> GetAll()
        {
            return AlumnoInscriptoData.GetAll();
        }
        public void Save(AlumnoInscripto AlumnoInscripto)
        {
            AlumnoInscriptoData.Save(AlumnoInscripto);
        }
        public void Delete(int ID)
        {
            AlumnoInscriptoData.Delete(ID);
        }
    }
}
