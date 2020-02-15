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
    public class InscripcionesBLL
    {
        public static bool Guardar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.inscripcionT.Add(inscripcion) != null)
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

        public static bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(inscripcion).State = EntityState.Modified;
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
                var eliminar = db.inscripcionT.Find(id);
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

        public static Inscripciones Buscar (int id)
        {
            Inscripciones inscripcion = new Inscripciones();
            Contexto db = new Contexto();

            try
            {
                inscripcion = db.inscripcionT.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return inscripcion;
        }

        public static List<Inscripciones> GetList(Expression<Func<Inscripciones, bool>>inscripcion)
        {
            List<Inscripciones> lista = new List<Inscripciones>();
            Contexto db = new Contexto();

            try
            {
                lista = db.inscripcionT.Where(inscripcion).ToList();
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
