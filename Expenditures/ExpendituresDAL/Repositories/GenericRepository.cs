using ExpendituresDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL.Repositories
{
    public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : class, ITEntity<TId>
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(DbContext context)
        {
            _ctx = context;
            _DbSet = context.Set<T>();
        }

        public T Create(T model)
        {
            _DbSet.Add(model);
            SaveChanges();

            return model;
        }

        public void Delete(T model)
        {
            _DbSet.Attach(model);
            _DbSet.Remove(model);
            _ctx.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate)
        {
            return _DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public T GetById(TId id)
        {
            return _DbSet.Find(id);
        }

        public T Update(T model)
        {          
            _ctx.Entry(model).State = EntityState.Modified;
            SaveChanges();

            return model;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }      
    }

}
