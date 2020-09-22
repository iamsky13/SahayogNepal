using Microsoft.EntityFrameworkCore;
using SahayogNepal.Data;
using SahayogNepal.RepositoryAndSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SahayogNepal.RepositoryAndSpecification
{
    public class Repository<T> : IRepository<T>, IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T GetSingleBySpec(Expression<Func<T, bool>> spec)
        {
            return ListBySpec(spec).SingleOrDefault();
        }

        public T GetSingleBySpec(Specification<T> spec)
        {
            return ApplySpecification(spec).SingleOrDefault();
        }


        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<T> GetSingleBySpecAsync(Expression<Func<T, bool>> spec)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(spec);
        }

        public async Task<T> GetSingleBySpecAsync(Specification<T> spec)
        {
            return await ApplySpecification(spec).SingleOrDefaultAsync();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IEnumerable<T> ListBySpec(Expression<Func<T, bool>> spec)
        {
            IEnumerable<T> query = _dbContext.Set<T>().Where(spec).AsEnumerable();
            return query;
        }

        public IEnumerable<T> ListBySpec(Specification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        public int Count(Specification<T> spec)
        {
            return ApplySpecification(spec).Count();
        }

        public int Count(Expression<Func<T, bool>> spec)
        {
            return _dbContext.Set<T>().Count(spec);
        }

        public async Task<List<T>> ListBySpecAsync(Expression<Func<T, bool>> spec)
        {
            var query = await _dbContext.Set<T>().Where(spec).ToListAsync();
            return query;
        }

        public async Task<List<T>> ListBySpecAsync(Specification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(Specification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> spec)
        {
            return await _dbContext.Set<T>().CountAsync(spec);
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            //_dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            //await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            //_dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            //await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            //_dbContext.SaveChanges();
        }

        public void DeleteList(List<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
            //_dbContext.SaveChanges();
        }


        public IEnumerable<T> ExecQuery(string query, params object[] parameters)
        {
            return _dbContext.Set<T>().FromSqlRaw(query, parameters);
        }
        public IEnumerable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            DbSet<T> dbSet = _dbContext.Set<T>();

            IEnumerable<T> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
