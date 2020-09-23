using SahayogNepal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahayogNepal.RepositoryAndSpecification
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _entities;
        public GenericUnitOfWork(ApplicationDbContext context)
        {
            _entities = context;
        }

        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)) == true)
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new Repository<T>(_entities);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public bool Commit()
        {
            try
            {
                _entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //_entities.Dispose();
                GC.SuppressFinalize(this);
            }
        }
        public async Task<bool> CommitAsync()
        {
            try
            {
                await _entities.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //_entities.Dispose();
                GC.SuppressFinalize(this);

            }
        }
        public IAsyncRepository<T> AsyncRepository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)) == true)
            {
                return Repositories[typeof(T)] as IAsyncRepository<T>;
            }
            IAsyncRepository<T> repo = new Repository<T>(_entities);
            Repositories.Add(typeof(T), repo);
            return repo;
        }
    }
}
