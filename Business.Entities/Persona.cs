﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        [Flags]
        public enum TipoPersona
        {
            Alumno = 0b1,
            Docente = 0b10,
            NoDocente = 0b100
        }
        public TipoPersona Tipo { get;set; }
        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }

}