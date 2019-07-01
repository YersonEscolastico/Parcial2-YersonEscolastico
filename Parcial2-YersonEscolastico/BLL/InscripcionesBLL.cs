using Parcial2_YersonEscolastico.DAL;
using Parcial2_YersonEscolastico.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea6.BLL;

namespace Parcial2_YersonEscolastico.BLL
{
    public class InscripcionesBLL
    {
        public static bool Guardar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                RepositorioBase<Estudiantes> Est = new RepositorioBase<Estudiantes>();

                if (db.Inscripcion.Add(inscripcion) != null)
                {
                    var estudiante = Est.Buscar(inscripcion.EstudianteId);

                    inscripcion.CalcularMonto();
                    estudiante.Balance = (decimal)inscripcion.MontoInscripcion;
                    paso = db.SaveChanges() > 0;
                    Est.Modificar(estudiante);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Inscripciones inscripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> Est = new RepositorioBase<Estudiantes>();


            try
            {
                var estudiante = Est.Buscar(inscripcion.EstudianteId);
                var anterior = new RepositorioBase<Inscripciones>().Buscar(inscripcion.InscripcionId);
                estudiante.Balance -= (decimal)anterior.MontoInscripcion;

                foreach (var item in anterior.Asignaturas)
                {
                    if (!inscripcion.Asignaturas.Any(A => A.InscripcionDetallesId == item.InscripcionDetallesId))
                    {
                        db.Entry(item).State = EntityState.Deleted;

                    }
                }
                foreach (var item in inscripcion.Asignaturas)
                {
                    if (item.InscripcionDetallesId == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                }

                inscripcion.CalcularMonto();
                estudiante.Balance += (decimal)inscripcion.MontoInscripcion;
                Est.Modificar(estudiante);

                db.Entry(inscripcion).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> Est = new RepositorioBase<Estudiantes>();
            try
            {
                var Inscripcion = db.Inscripcion.Find(id);
                var estudiante = Est.Buscar(Inscripcion.EstudianteId);
                estudiante.Balance = estudiante.Balance - Inscripcion.MontoInscripcion;
                Est.Modificar(estudiante);
                db.Entry(Inscripcion).State = EntityState.Deleted;
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

        public static Inscripciones Buscar(int id)
        {
            Inscripciones entity;
            Contexto db = new Contexto();

            try
            {
                entity = db.Set<Inscripciones>().Find(id);

                if (entity != null)
                {
                    entity.Asignaturas.Count();                  
                }
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

    }
}
