using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
        public class AcademiaContext : DbContext
        {
            public AcademiaContext() : base("AcademiaTP") {}
            public DbSet<Usuario> Usuario { get; set; }
            public DbSet<Persona> Persona { get; set; }
            public DbSet<AlumnoInscripto> AlumnoInscripto { get; set; }
            public DbSet<Comision> Comision { get; set; }
            public DbSet<Curso> Curso { get; set; }
            public DbSet<DocenteCurso> DocenteCurso { get; set; }
            public DbSet<Especialidad> Especialidad { get; set; }
            public DbSet<Materia> Materia { get; set; }
            public DbSet<Plan> Plan { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
            .HasOptional(p => p.Usuario);
        }
    }

}
