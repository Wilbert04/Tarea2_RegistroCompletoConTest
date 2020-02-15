using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroConTest.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionID { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaID { get; set; }

        public string Comentarios { get; set; }
        public float Monto { get; set; }
        public float Balance { get; set; }

        public Inscripciones()
        {
            InscripcionID = 0;
            Fecha = DateTime.Now;
            PersonaID= 0;
            Comentarios = string.Empty;
            Monto = 0.00f;
            Balance = 0.00f;
        }
    }
}
