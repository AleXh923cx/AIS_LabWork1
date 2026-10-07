using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        public void Add(T entity)
        {
            using var ctx = new DBContext();
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            using var ctx = new DBContext();
            var origin = ctx.Set<T>().FirstOrDefault(x => x.Id == id);
            if (origin == null) return;
            ctx.Set<T>().Remove(origin);
            ctx.SaveChanges();
        }

        public IEnumerable<T> ReadAll()
        {
            using var ctx = new DBContext();
            return ctx.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            using var ctx = new DBContext();
            return ctx.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            using var ctx = new DBContext();
            var origin = ctx.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            if (origin == null) return;
            ctx.Entry(origin).CurrentValues.SetValues(entity);
            ctx.SaveChanges();
        }
    }
}
