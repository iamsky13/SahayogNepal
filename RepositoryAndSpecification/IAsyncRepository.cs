using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SahayogNepal.RepositoryAndSpecification
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetSingleBySpecAsync(Expression<Func<T, bool>> spec);
        Task<T> GetSingleBySpecAsync(Specification<T> spec);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListBySpecAsync(Expression<Func<T, bool>> spec);
        Task<List<T>> ListBySpecAsync(Specification<T> spec);
        Task<int> CountAsync(Specification<T> spec);
        Task<int> CountAsync(Expression<Func<T, bool>> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}

