using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpendituresDAL.Interfaces
{
    public interface IGenericRepository<T, TId> where T : class, ITEntity<TId>
    {
        T Create(T Model);
        T Update(T Model);
        void Delete(T Model);
        T GetById(TId id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}

