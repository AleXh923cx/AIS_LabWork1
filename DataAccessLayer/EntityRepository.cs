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
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
