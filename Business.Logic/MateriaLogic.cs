using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        Data.Database.MateriaAdapter MateriaData { get; set; }
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }
        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }
        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }
        public void Save(Materia Materia)
        {
            MateriaData.Save(Materia);
        }
        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }
    }
}
