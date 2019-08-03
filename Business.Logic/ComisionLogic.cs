using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        Data.Database.ComisionAdapter ComisionData { get; set; }
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }
        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }
        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }
        public void Save(Comision Comision)
        {
            ComisionData.Save(Comision);
        }
        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }
    }
}
