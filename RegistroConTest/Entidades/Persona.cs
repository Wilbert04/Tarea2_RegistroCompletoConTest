using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroConTest.Entidades
{
    public class Persona
    {

        [Key]
        public int PersonaId { get; set; }
        public string Matricula { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public float Balance { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Matricula = string.Empty;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
            Balance = 0.0f;
        }
    }
}
