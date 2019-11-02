using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class EspecialidadAdapter
    {
            SqlConnection conn = new SqlConnection();

            public List<Especialidad> GetAll()
            {
                using (var context = new AcademiaContext())
                {
                    conn = (SqlConnection)context.Database.Connection;
                    conn.Open();
                    List<Especialidad> especialidades = new List<Especialidad>();
                    SqlCommand comando = new SqlCommand("Select * from Especialidads", conn);
                    SqlDataReader drEspecialidades = comando.ExecuteReader();
                    while (drEspecialidades.Read())
                    {
                        Especialidad es = new Especialidad();
                        es.ID = (int)drEspecialidades["ID"];
                        es.Descripcion = (String)drEspecialidades["Descripcion"];
                        especialidades.Add(es);
                    }
                    drEspecialidades.Close();
                    conn.Close();
                    conn = null;
                    return especialidades;
                }
            }

            public Business.Entities.Especialidad GetOne(int ID)
            {
                using (var context = new AcademiaContext())
                {
                    Especialidad es = new Especialidad();
                    conn = (SqlConnection)context.Database.Connection;
                    conn.Open();
                    SqlCommand comando = new SqlCommand("Select * from Especialidads where ID=@id", conn);
                    comando.Parameters.AddWithValue("@id", ID);
                    SqlDataReader drEspecialidades = comando.ExecuteReader();
                    while (drEspecialidades.Read())
                    {
                        es.ID = (int)drEspecialidades["ID"];
                        es.Descripcion = (String)drEspecialidades["Descripcion"];
                    }
                    drEspecialidades.Close();
                    conn.Close();
                    conn = null;
                    return es;
                }
        }


            public void Delete(int ID)
            {
                using (var context = new AcademiaContext())
                {
                    conn = (SqlConnection)context.Database.Connection;
                    conn.Open();
                    SqlCommand comando = new SqlCommand("Delete from Especialidads where ID=@id", conn);
                    comando.Parameters.AddWithValue("@id", ID);
                    comando.ExecuteNonQuery();
                    conn.Close();
                    conn = null;
                }
            }

            protected void Update(Especialidad entity)
            {
                using (var context = new AcademiaContext())
                {
                    conn = (SqlConnection)context.Database.Connection;
                    conn.Open();
                    SqlCommand comando = new SqlCommand("Update Especialidads set Descripcion=@desc where ID=@id", conn);
                    comando.Parameters.AddWithValue("@id", entity.ID);
                    comando.Parameters.AddWithValue("@desc", entity.Descripcion);
                    comando.ExecuteNonQuery();
                    conn.Close();
                    conn = null;
                }
            }
            protected void Insert(Especialidad entity)
            {
                using (var context = new AcademiaContext())
                {
                    conn = (SqlConnection)context.Database.Connection;
                    conn.Open();
                    SqlCommand comando = new SqlCommand("Insert into Especialidads(Descripcion) values (@desc)", conn);
                    comando.Parameters.AddWithValue("@desc", entity.Descripcion);
                    comando.ExecuteNonQuery();
                    conn.Close();
                    conn = null;
                }
            }

            public void Save(Especialidad entity)
            {
                switch (entity.State)
                {
                    case BusinessEntity.States.Deleted:
                        Delete(entity.ID);
                        break;
                    case BusinessEntity.States.New:
                        Insert(entity);
                        break;
                    case BusinessEntity.States.Modified:
                        Update(entity);
                        break;
                    default:
                        entity.State = BusinessEntity.States.Unmodified;
                        break;
                }
            }
        }
    }