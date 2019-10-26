using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        Data.Database.PersonaAdapter PersonaData { get; set; }
        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }
        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }
        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }
        public Persona FindByLegajo(int legajo)
        {
            return PersonaData.FindByLegajo(legajo);
        }
        public void Save(Persona Persona)
        {
            PersonaData.Save(Persona);
        }
        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }
    }
}
