using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Inscripciones> Inscripcion { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
