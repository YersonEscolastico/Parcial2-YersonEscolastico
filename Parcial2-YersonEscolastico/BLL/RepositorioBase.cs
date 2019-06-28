using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Parcial2_YersonEscolastico.BLL;
using Parcial2_YersonEscolastico.DAL;


namespace Tarea6.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {

        internal Contexto db;

        public RepositorioBase()
        {
            db = new Contexto();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (db.Set<T>().Add(entity) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;

            try
            {

                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public T Buscar(int id)
        {
            T entity;

            try
            {
                entity = db.Set<T>().Find(id);

            }
            catch (Exception)
            {
                throw;
            }


            return entity;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> lista;

            try
            {
                lista = db.Set<T>().Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }


            return lista;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            T entity;

            try
            {
                entity = db.Set<T>().Find(id);
                db.Entry(entity).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public void Dispose()
        {
            db.Dispose();
        }
       
    }
}
