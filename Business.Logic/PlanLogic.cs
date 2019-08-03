using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        Data.Database.PlanAdapter PlanData { get; set; }
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }
        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }
        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }
        public void Save(Plan Plan)
        {
            PlanData.Save(Plan);
        }
        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
    }
}
