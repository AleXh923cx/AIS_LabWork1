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
        private readonly DBContext _ctx;

        public EntityRepository()
        {
            _ctx = new DBContext();
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var origin = _ctx.Set<T>().FirstOrDefault(x => x.Id == id);
            if (origin == null) return;
            _ctx.Set<T>().Remove(origin);
            _ctx.SaveChanges();
        }

        public IEnumerable<T> ReadAll() => _ctx.Set<T>().ToList();

        public T ReadById(int id) => _ctx.Set<T>().FirstOrDefault(x => x.Id == id);

        public void Update(T entity)
        {
            var origin = _ctx.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            if (origin == null) return;
            _ctx.Entry(origin).CurrentValues.SetValues(entity);
            _ctx.SaveChanges();
        }
    }
}
