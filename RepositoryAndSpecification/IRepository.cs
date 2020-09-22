using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SahayogNepal.RepositoryAndSpecification
{
    public interface IRepository<T>
    {
        T GetSingleBySpec(Expression<Func<T, bool>> spec);
        T GetSingleBySpec(Specification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> ListBySpec(Expression<Func<T, bool>> spec);
        IEnumerable<T> ListBySpec(Specification<T> spec);
        int Count(Specification<T> spec);
        int Count(Expression<Func<T, bool>> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteList(List<T> entity);

        IEnumerable<T> ExecQuery(string query, params object[] parameters);
        IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
