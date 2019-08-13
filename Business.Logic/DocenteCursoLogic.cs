using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        Data.Database.DocenteCursoAdapter DocenteCursoData { get; set; }
        public DocenteCursoLogic()
        {
            DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }
        public DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }
        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }
        public List<DocenteCurso> ListByCurso(Curso curso)
        {
            return DocenteCursoData.ListByCurso(curso);
        }
        public void Save(DocenteCurso DocenteCurso)
        {
            DocenteCursoData.Save(DocenteCurso);
        }
        public void Delete(int ID)
        {
            DocenteCursoData.Delete(ID);
        }
    }
}
