using Microsoft.EntityFrameworkCore;
using RegistroConTest.DAL;
using RegistroConTest.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroConTest.BLL
{
    public class PersonaBLL
    {
        public static bool Guardar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.personaT.Add(persona) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }

        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.personaT.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }

        public static Persona Guardar(int id)
        {
            Persona persona = new Persona();
            Contexto db = new Contexto();

            try
            {
                persona = db.personaT.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return persona;
        }

        public static Persona Buscar(int id)
        {
            Persona persona = new Persona();
            Contexto db = new Contexto();

            try
            {
                persona = db.personaT.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return persona;
        }

        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            List<Persona> lista = new List<Persona>();
            Contexto db = new Contexto();

            try
            {
                lista = db.personaT.Where(persona).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return lista;
        }
    }
}
