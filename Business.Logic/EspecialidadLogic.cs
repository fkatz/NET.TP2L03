using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        Data.Database.EspecialidadAdapter EspecialidadData { get; set; }
        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }
        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }
        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }
        public void Save(Especialidad Especialidad)
        {
            EspecialidadData.Save(Especialidad);
        }
        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }
    }
}
