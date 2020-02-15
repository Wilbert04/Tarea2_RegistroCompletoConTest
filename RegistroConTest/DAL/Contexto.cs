using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroConTest.Entidades;

namespace RegistroConTest.DAL
{
    public class Contexto : DbContext               // SE HEREDA DE DB CONTEXT 
    {

        public DbSet<Persona> personaT { get; set; }
        public DbSet<Inscripciones> inscripcionT { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // PROPIEDAD QUE GUARDARA EN LA BASE DB
        {

            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = RegistroTestDB; Trusted_Connection = True; ");
        }                   // AQUI SE AGREGA UN STRING, SE PASA EL NOMBRE DEL SERVIDOR, NOMBRE DE LA DB Y POR ULTIMO EL TIPO DE CONEXION

    }
}
